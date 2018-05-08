using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Castle.Core.Internal;
using CP.Platform.Test.Core.Helpers;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.EmployeeToLegalEntity.Models;
using CP.Shared.Contract.LegalEntity.Models;
using CP.Shared.Test.Contract.EmployeeToLegalEntity.Models;

namespace CP.Shared.Test.Contract.EmployeeToLegalEntity.Helpers
{
    public static class EmployeeToLegalEntityHelper
    {
        public static EmployeeToLegalEntityView Map(IFixture fixture,
            EmployeeToLegalEntityViewCustomizationModel model, EmployeeToLegalEntityView employeeToLegalEntity)
        {
            employeeToLegalEntity.Employee = fixture.Create<List<EmployeeView>>()
                .First(e => e.Name == model.Employee);
            employeeToLegalEntity.LegalEntity = fixture.Create<List<LegalEntityView>>()
                .First(le => le.Name == model.LegalEntity);
            if (!model.IsPrimary.IsNullOrEmpty())
            {
                employeeToLegalEntity.IsPrimary = HelperService.ParseBool(model.IsPrimary);
            }

            return employeeToLegalEntity;
        }
    }
}