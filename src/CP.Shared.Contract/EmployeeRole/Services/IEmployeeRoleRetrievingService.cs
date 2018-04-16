using System;
using System.Collections.Generic;
using CP.Shared.Contract.Core.Services;
using CP.Shared.Contract.EmployeeRole.Models;

namespace CP.Shared.Contract.EmployeeRole.Services
{
    public interface IEmployeeRoleRetrievingService : ISimpleRetrievingService<EmployeeRoleView>
    {
        IEnumerable<EmployeeRoleView> GetByEmployee(Guid employeeId);
    }
}