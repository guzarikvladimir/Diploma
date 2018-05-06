using System;
using System.Collections.Generic;
using CP.Shared.Contract.Core.Services;
using CP.Shared.Contract.EmployeeToLegalEntity.Models;

namespace CP.Shared.Contract.EmployeeToLegalEntity.Services
{
    public interface IEmployeeToLegalEntityRetrievingService : ISimpleRetrievingService<EmployeeToLegalEntityView>
    {
        IEnumerable<EmployeeToLegalEntityView> Get(Guid employeeId, bool isActive = true);
    }
}