using System;
using System.Collections.Generic;
using System.Linq;
using CP.Shared.Contract.EmployeeRole.Models;
using CP.Shared.Contract.EmployeeRole.Services;
using CP.Shared.Core.Services;
using EmployeeRoleEntity = CP.Repository.Models.EmployeeRole;

namespace CP.Shared.EmployeeRole.Services
{
    public class EmployeeRoleRetrievingService : 
        SimpleRetrievingService<EmployeeRoleEntity, EmployeeRoleView>,
        IEmployeeRoleRetrievingService
    {
        public IEnumerable<EmployeeRoleView> GetByEmployee(Guid employeeId)
        {
            return Get().Where(er => er.Employee.Id == employeeId);
        }
    }
}