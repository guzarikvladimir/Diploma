using System;
using System.Collections.Generic;
using CP.Platform.Crud.Contract;
using CP.Shared.Contract.EmployeeLegalEntity.Models;

namespace CP.Shared.Contract.EmployeeLegalEntity.Services
{
    public interface IEmployeeLegalEntityRetrievingService : ISimpleRetrievingService<EmployeeLegalEntityView>
    {
        IEnumerable<EmployeeLegalEntityView> Get(Guid employeeId, bool isActive = true);
    }
}