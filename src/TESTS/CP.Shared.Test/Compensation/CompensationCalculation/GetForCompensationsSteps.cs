using System;
using System.Collections.Generic;
using AutoFixture;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Compensation.Services;
using CP.Shared.Contract.Bonus.Models;
using CP.Shared.Contract.Compensation.Models;
using CP.Shared.Contract.Compensation.Services;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Contract.CurrencyRate.Services;
using CP.Shared.Contract.Salary.Models;
using CP.Shared.Currency.Services;
using CP.Shared.CurrencyRate.Services;
using Ninject;
using NUnit.Framework;
using TechTalk.SpecFlow;
using GetCurrencies = CP.Shared.Test.Contract.Currency.Mocks.CurrencyRetrieving.GetSteps;
using GetCurrencyById = CP.Shared.Test.Contract.Currency.Mocks.CurrencyRetrieving.GetByIdSteps;
using GetCurrencyRates = CP.Shared.Test.Contract.CurrencyRate.Mocks.CurrencyRateRetrieving.GetSteps;
using GetDefaultCurrency = CP.Shared.Test.Contract.Currency.Mocks.CurrencyRetrieving.GetDefaultSteps;

namespace CP.Shared.Test.Compensation.CompensationCalculation
{
    [Binding]
    public class GetForCompensationsSteps : StepsBase
    {
        private ValueWithCurrency Result;

        public GetForCompensationsSteps(BaseTestData data) : base(data)
        {
        }

        [Given(@"Requestor is going to calculate compensations")]
        public void GivenRequestorIsGoingToCalculateCompensations()
        {
            BindInSingletonScope<ICompensationCalculationService, CompensationCalculationService>();
            BindInSingletonScope<ICurrencyResolverService, CurrencyResolverService>();
            BindInSingletonScope<ICurrencyConverterService, CurrencyConverterService>();
            BindInSingletonScope<ICurrencyRateService, CurrencyRateService>();
            
            Given(GetCurrencies.Default);
            Given(GetCurrencyById.Default);
            Given(GetCurrencyRates.Default);
            Given(GetDefaultCurrency.Default);
        }

        [When(@"Calculate compensations is requested")]
        public void WhenCalculateCompensationsIsRequestedForCompensations()
        {
            var compensations = new List<CompensationPromotionView>();
            var salaries = Fixture.Create<List<SalaryPromotionView>>();
            var bonuses = Fixture.Create<List<BonusPromotionView>>();
            compensations.AddRange(salaries);
            compensations.AddRange(bonuses);

            Result = Kernel.Get<ICompensationCalculationService>().Get(compensations, Guid.Empty, null);
        }

        [Then(@"Total value should be (.*)")]
        public void ThenTotalValueShouldBe(decimal value)
        {
            Assert.AreEqual(value, Result.Value);
        }

        [Then(@"Result currency should be (.*)")]
        public void ThenResultCurrencyShouldBy(string name)
        {
            Assert.AreEqual(name.ToLower(), Result.Currency.Name.ToLower());
        }
    }
}