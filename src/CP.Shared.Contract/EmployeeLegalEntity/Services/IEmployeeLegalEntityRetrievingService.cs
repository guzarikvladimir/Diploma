using System;
using System.Collections.Generic;
using CP.Shared.Contract.Core.Services;
using CP.Shared.Contract.EmployeeLegalEntity.Models;

namespace CP.Shared.Contract.EmployeeLegalEntity.Services
{
    public interface IEmployeeLegalEntityRetrievingService : ISimpleRetrievingService<EmployeeLegalEntityView>
    {
        IEnumerable<EmployeeLegalEntityView> Get(Guid employeeId, bool isActive = true);
    }
}