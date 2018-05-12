using System;
using System.Collections.Generic;
using System.Linq;
using CP.Platform.Identity.Contract;
using CP.Platform.Identity.Helpers;
using CP.Shared.Contract.EmployeeRole.Services;
using CP.Shared.Contract.Role.Models;
using Ninject;
using RoleEnum = CP.Shared.Contract.Role.Models.Role;

namespace CP.Shared.EmployeeRole.Services
{
    public class EmployeeRoleService : IEmployeeRoleService
    {
        #region Injects

        [Inject]
        IEmployeeRoleRetrievingService EmployeeRoleRetrievingService { get; set; }

        [Inject]
        IUserService UserService { get; set; }

        #endregion

        public bool IsInRole(Guid employeeId, params RoleEnum[] roles)
        {
            List<RoleView> employeeRols = Get(employeeId);

            return employeeRols.Any(er => roles.Any(r => er == r));
        }

        public bool IsInRole(params RoleEnum[] roles)
        {
            Guid userId = UserService.Current.GetUserId();

            return IsInRole(userId, roles);
        }

        public List<RoleView> Get(Guid employeeId)
        {
            List<RoleView> employeeRoles = EmployeeRoleRetrievingService.Get()
                .Where(er => er.Employee.Id == employeeId)
                .Select(er => er.Role)
                .ToList();

            return employeeRoles;
        }
    }
}