using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Configuration;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Contract.EmployeeRole.Models;
using CP.Shared.Contract.EmployeeRole.Services;
using CP.Shared.Contract.User.Models;
using CP.Shared.Contract.User.Services;
using Ninject;
using WebApi.Contract;
using WebApi.Models;

namespace WebApi.Services
{
    public class UserService : IUserService
    {
        #region Injects

        [Inject]
        IUserRetrievingService UserRetrievingService { get; set; }

        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        [Inject]
        IEmployeeRoleRetrievingService EmployeeRoleRetrievingService { get; set; }

        #endregion

        public ClaimsIdentity Login(LoginView model)
        {
            UserView user = UserRetrievingService.Get().FirstOrDefault(u => u.Email == model.Email);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user.Email));
            }

            if (user.Password != model.Password)
            {
                throw new ActivationException(nameof(user.Password));
            }

            EmployeeView employee = EmployeeRetrievingService.GetById(user.Id);
            ClaimsIdentity claim = new ClaimsIdentity(WebConfigurationManager.AppSettings["AuthenticationType"], 
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
            claim.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, employee.Name, ClaimValueTypes.String));
            claim.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", 
                "OWIN Provider", ClaimValueTypes.String));
            IEnumerable<EmployeeRoleView> employeeRoles = EmployeeRoleRetrievingService.GetByEmployee(employee.Id);
            foreach (EmployeeRoleView employeeRole in employeeRoles)
            {
                claim.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, employeeRole.Role.Name, ClaimValueTypes.String));
            }

            return claim;
        }
    }
}