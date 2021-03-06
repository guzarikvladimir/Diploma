﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Configuration;
using CP.Authorization.Contract.Models;
using CP.Authorization.Contract.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Contract.EmployeeRole.Services;
using CP.Shared.Contract.Role.Models;
using CP.Shared.Contract.User.Models;
using CP.Shared.Contract.User.Services;
using Ninject;

namespace CP.Authorization.Services
{
    public class UserService : IUserService
    {
        #region Injects

        [Inject]
        IUserRetrievingService UserRetrievingService { get; set; }

        [Inject]
        IUserModifyingService UserModifyingService { get; set; }

        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        [Inject]
        IEmployeeRoleService EmployeeRoleService { get; set; }

        [Inject]
        IEntityMapper<RegisterView, UserModel> ModelMapper { get; set; }

        #endregion

        public ClaimsIdentity Login(LoginView model)
        {
            EmployeeView employee = EmployeeRetrievingService.Get().FirstOrDefault(e => e.Email == model.Email);
            if (employee == null)
            {
                throw new ArgumentException($"User with email {model.Email} is not an employee.");
            }

            UserView user = UserRetrievingService.GetById(employee.Id);
            if (user == null)
            {
                throw new ArgumentException($"User with email {model.Email} is not registed.");
            }

            if (user.Password != model.Password)
            {
                throw new ArgumentException("Invalid password.");
            }
            
            ClaimsIdentity claim = new ClaimsIdentity(WebConfigurationManager.AppSettings["AuthenticationType"], 
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
            claim.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, employee.Name, ClaimValueTypes.String));
            claim.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", 
                "OWIN Provider", ClaimValueTypes.String));
            List<RoleView> employeeRoles = EmployeeRoleService.Get(employee.Id);
            foreach (RoleView role in employeeRoles)
            {
                claim.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Name, ClaimValueTypes.String));
            }

            return claim;
        }

        public void Register(RegisterView view)
        {
            EmployeeView employee = EmployeeRetrievingService.Get().FirstOrDefault(e => e.Email == view.Email);
            if (employee == null)
            {
                throw new ArgumentException("You don't have permissions to register, because you are not an employee.");
            }

            UserView user = UserRetrievingService.GetById(employee.Id);
            if (user != null)
            {
                throw new ArgumentException($"User with email {employee.Email} already registered.");
            }

            UserModel model = ModelMapper.Map(view);
            model.Id = employee.Id;
            UserModifyingService.AddOrUpdate(model);
        }
    }
}