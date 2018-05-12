using System;
using System.Collections.Generic;
using System.Linq;
using CP.Compensation.Table.Contract;
using CP.Compensation.Table.Models;
using CP.Compensation.Table.Services;
using CP.Compensation.Test.Contract.Table.Helpers;
using CP.Compensation.Test.Contract.Table.Models;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Bonus.Services;
using CP.Shared.Compensation.Services;
using CP.Shared.CompensationPromotion.Services;
using CP.Shared.Contract.Bonus.Services;
using CP.Shared.Contract.Compensation.Services;
using CP.Shared.Contract.CompensationPromotion.Services;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Contract.CurrencyRate.Services;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Contract.Salary.Services;
using CP.Shared.Currency.Services;
using CP.Shared.CurrencyRate.Services;
using CP.Shared.Employee.Services;
using CP.Shared.Salary.Services;
using CP.Shared.Test.Contract.Filters.Helpers;
using Ninject;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using GetEmployees = CP.Shared.Test.Contract.Employee.Mocks.EmployeeRetrieving.GetSteps;
using GetSalaries = CP.Shared.Test.Contract.Salary.Mocks.SalaryPromotionRetrieving.GetSteps;
using GetBonuses = CP.Shared.Test.Contract.Bonus.Mocks.BonusPromotionRetrieving.GetSteps;
using GetEmployeeToLegalEntities = CP.Shared.Test.Contract.EmployeeLegalEntity.Mocks.EmployeeLegalEntityRetrieving.GetSteps;
using GetCurrencies = CP.Shared.Test.Contract.Currency.Mocks.CurrencyRetrieving.GetSteps;
using GetCurrencyById = CP.Shared.Test.Contract.Currency.Mocks.CurrencyRetrieving.GetByIdSteps;
using GetCurrencyRates = CP.Shared.Test.Contract.CurrencyRate.Mocks.CurrencyRateRetrieving.GetSteps;
using CP.Platform.Helpers;
using CP.Platform.Period.Helpers;
using CP.Shared.Contract.Filters.Services;
using CP.Shared.Filters.Services;

namespace CP.Compensation.Test.Table.CompensationTable
{
    [Binding]
    public class GetForCompensationsSteps : StepsBase
    {
        private CompensationTableView Result;

        public GetForCompensationsSteps(BaseTestData data) : base(data)
        {
        }

        [Given(@"Requestor is going to get compensation table")]
        public void GivenRequestorIsGoingToGetCompensationTable()
        {
            BindInSingletonScope<ICompensationTableSerivce, CompensationTableSerivce>();
            BindInSingletonScope<IEmployeeSerice, EmployeeSerice>();
            BindInSingletonScope<ICompensationPromotionFilterService, CompensationPromotionFilterService>();
            BindInSingletonScope<ICompensationPromotionService, CompensationPromotionService>();
            BindInSingletonScope<ISalaryPromotionService, SalaryPromotionService>();
            BindInSingletonScope<IBonusPromotionSerivce, BonusPromotionSerivce>();
            BindInSingletonScope<ICompensationCalculationService, CompensationCalculationService>();
            BindInSingletonScope<ICurrencyResolverService, CurrencyResolverService>();
            BindInSingletonScope<ICurrencyService, CurrencyService>();
            BindInSingletonScope<ICurrencyConverterService, CurrencyConverterService>();
            BindInSingletonScope<ICurrencyRateService, CurrencyRateService>();

            Given(GetEmployees.Default);
            Given(GetSalaries.Default);
            Given(GetBonuses.Default);
            Given(GetEmployeeToLegalEntities.Default);
            Given(GetCurrencyById.Default);
            Given(GetCurrencies.Default);
            Given(GetCurrencyRates.Default);
        }

        [When(@"Compensation table is requested with parameters")]
        public void WhenCompensationTableIsRequestedWithParameters(TechTalk.SpecFlow.Table table)
        {
            var model = table.CreateInstance<CompensationTableParametersCustomizationModel>();
            var parameters = CollectionViewParametersHelper.Map<CompensationTableParameters>(Fixture, model);

            Result = Kernel.Get<ICompensationTableSerivce>().Get(parameters);
        }

        [When(@"Compensation table is requested without parameters")]
        public void WhenCompensationTableIsRequestedWithoutParameters()
        {
            Result = Kernel.Get<ICompensationTableSerivce>().Get(new CompensationTableParameters());
        }

        [Then(@"Employees compensations should be")]
        public void ThenEmployeesCompensationsShouldBe(TechTalk.SpecFlow.Table table)
        {
            List<IGrouping<Guid, CompensationTableViewTestModel>> expectedModels = GetExpectedModels(table);

            Assert.AreEqual(expectedModels.Count, Result.CompensationsByEmployees.Count, "Rows count are not equal");
            foreach (IGrouping<Guid, CompensationTableViewTestModel> expectedEmployeeCompensations in expectedModels)
            {
                var actualEmployeeCompensations = Result.CompensationsByEmployees
                    .First(c => c.Employee.Id == expectedEmployeeCompensations.Key);
                foreach (CompensationTableViewTestModel expectedCompensationByPeriod in expectedEmployeeCompensations)
                {
                    var actualCompensationsByPeriod = actualEmployeeCompensations.CompensationsByPeriods
                        .FirstOrDefault(cp => cp.Period.ToPeriod() == expectedCompensationByPeriod.Period);
                    int actualCount = actualCompensationsByPeriod?.CompensationPromotions?.Count() ?? 0;
                    Assert.AreEqual(expectedCompensationByPeriod.Compensations.Count, actualCount, 
                        $"Invalid compensations count for period {expectedCompensationByPeriod.Period}");
                    Assert.AreEqual(expectedCompensationByPeriod.Total?.Currency?.Name,
                        actualCompensationsByPeriod?.Total?.Currency?.Name, 
                        $"Invalid total currency for period {expectedCompensationByPeriod.Period}");
                    Assert.AreEqual(expectedCompensationByPeriod.Total?.Value,
                        actualCompensationsByPeriod?.Total?.Value,
                        $"Invalid total value for period {expectedCompensationByPeriod.Period}");
                }
            }
        }

        [Then(@"Employee year totals should be")]
        public void ThenEmployeeYearTotalShouldBe(TechTalk.SpecFlow.Table table)
        {
            List<EmployeeTotalTestModel> expectedModels = GetExpectedTotalModels(table);

            foreach (EmployeeTotalTestModel expected in expectedModels)
            {
                var actual = Result.CompensationsByEmployees
                    .FirstOrDefault(m => m.Employee.Id == expected.Employee.Id);
                Assert.AreEqual(expected.Total?.Currency?.Name, actual?.Total?.Currency?.Name, 
                    "Invalid employee total currency");
                Assert.AreEqual(expected.Total?.Value, actual?.Total?.Value, 
                    "Invalid employee total value");
            }
        }

        private List<IGrouping<Guid, CompensationTableViewTestModel>> GetExpectedModels(TechTalk.SpecFlow.Table table)
        {
            List<CompensationTableViewTestModel> expectedModels = new List<CompensationTableViewTestModel>();
            foreach (var model in table.CreateSet<CompensationTableViewCustomizationModel>())
            {
                CompensationTableViewTestModel expected = CompensationTableHelper.Map(Fixture, model);
                expectedModels.Add(expected);
            }

            return expectedModels.GroupBy(m => m.Employee.Id).ToList();
        }

        private List<EmployeeTotalTestModel> GetExpectedTotalModels(TechTalk.SpecFlow.Table table)
        {
            List<EmployeeTotalTestModel> testModels = new List<EmployeeTotalTestModel>();
            foreach (var model in table.CreateSet<EmployeeTotalCustomizationModel>())
            {
                var testModel = EmployeeTotalHelper.Map(Fixture, model);
                testModels.Add(testModel);
            }

            return testModels;
        }
    }
}