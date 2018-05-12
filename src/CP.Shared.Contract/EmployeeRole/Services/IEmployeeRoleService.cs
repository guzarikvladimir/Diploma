using System;
using System.Collections.Generic;
using CP.Shared.Contract.Role.Models;
using RoleEnum = CP.Shared.Contract.Role.Models.Role;

namespace CP.Shared.Contract.EmployeeRole.Services
{
    public interface IEmployeeRoleService
    {
        bool IsInRole(Guid employeeId, params RoleEnum[] roles);

        bool IsInRole(params RoleEnum[] roles);

        List<RoleView> Get(Guid employeeId);
    }
}