using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.Compensation.Test.Contract.Table.Models;
using CP.Shared.Contract.Compensation.Models;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Employee.Models;
using CP.SpecFlowEx.Test.Helpers;

namespace CP.Compensation.Test.Contract.Table.Helpers
{
    public static class EmployeeTotalHelper
    {
        public static EmployeeTotalTestModel Map(IFixture fixture, EmployeeTotalCustomizationModel model)
        {
            EmployeeTotalTestModel testModel = new EmployeeTotalTestModel();
            testModel.Employee = fixture.Create<List<EmployeeView>>().First(e => e.Name == model.Employee);
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