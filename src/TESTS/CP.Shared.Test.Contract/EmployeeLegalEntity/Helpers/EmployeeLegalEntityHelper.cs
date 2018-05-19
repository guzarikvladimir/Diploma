using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Castle.Core.Internal;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.EmployeeLegalEntity.Models;
using CP.Shared.Contract.LegalEntity.Models;
using CP.Shared.Test.Contract.EmployeeLegalEntity.Models;
using CP.SpecFlowEx.Test.Helpers;

namespace CP.Shared.Test.Contract.EmployeeLegalEntity.Helpers
{
    public static class EmployeeLegalEntityHelper
    {
        public static EmployeeLegalEntityView Map(IFixture fixture,
            EmployeeLegalEntityViewCustomizationModel model, EmployeeLegalEntityView employeeLegalEntity)
        {
            employeeLegalEntity.Employee = fixture.Create<List<EmployeeView>>()
                .First(e => e.Name == model.Employee);
            employeeLegalEntity.LegalEntity = fixture.Create<List<LegalEntityView>>()
                .First(le => le.Name == model.LegalEntity);
            if (!model.IsPrimary.IsNullOrEmpty())
            {
                employeeLegalEntity.IsPrimary = HelperService.ParseBool(model.IsPrimary);
            }

            return employeeLegalEntity;
        }
    }
}