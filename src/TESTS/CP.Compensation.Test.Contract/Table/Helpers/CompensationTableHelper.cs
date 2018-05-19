using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.Compensation.Test.Contract.Table.Models;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Compensation.Models;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Test.Contract.CompensationPromotion.Models;
using CP.SpecFlowEx.Test.Helpers;

namespace CP.Compensation.Test.Contract.Table.Helpers
{
    public static class CompensationTableHelper
    {
        public static CompensationTableViewTestModel Map(IFixture fixture,
            CompensationTableViewCustomizationModel model)
        {
            CompensationTableViewTestModel testModel = new CompensationTableViewTestModel();
            testModel.Employee = fixture.Create<List<EmployeeView>>().First(e => e.Name == model.Employee);
            if (!HelperService.IsNull(model.Period))
            {
                testModel.Period = HelperService.ParsePeriod(model.Period);
            }
            if (!HelperService.IsNull(model.Compensations))
            {
                foreach (string compensationName in HelperService.GetCommaSeparatedValues(model.Compensations))
                {
                    CompensationPromotionView compensation = fixture.Create<List<CompensationpromotionViewTestModel>>()
                        .First(cp => cp.Name == compensationName).Entity;
                    testModel.Compensations.Add(compensation);
                }
            }
            if (!HelperService.IsNull(model.Total))
            {
                var value = decimal.Parse(model.Total);
                var currency = fixture.Create<List<CurrencyView>>().First(c => c.Name == model.Currency);
                testModel.Total = new ValueWithCurrency(value, currency);
            }

            return testModel;
        }
    }
}