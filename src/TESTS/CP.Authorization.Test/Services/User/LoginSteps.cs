using System;
using System.Security.Claims;
using CP.Authorization.Contract.Models;
using CP.Authorization.Contract.Services;
using CP.Authorization.Services;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Contract.EmployeeRole.Services;
using CP.Shared.EmployeeRole.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using GetEmployees = CP.Shared.Test.Contract.Employee.Mocks.EmployeeRetrieving.GetSteps;
using GetUsers = CP.Shared.Test.Contract.User.Mocks.UserRetrieving.GetSteps;
using GetEmployeeRoles = CP.Shared.Test.Contract.EmployeeRole.Mocks.EmployeeRoleRetrieving.Get;
using GetUserById = CP.Shared.Test.Contract.User.Mocks.UserRetrieving.GetByIdSteps;

namespace CP.Authorization.Test.Services.User
{
    [Binding]
    public class LoginSteps : StepsBase
    {
        public LoginSteps(BaseTestData data) : base(data)
        {
        }

        ClaimsIdentity Result { get; set; }

        [Given(@"Requestor is going to be loginned")]
        public void GivenRequestorIsGoingToBeLoginned()
        {
            BindInSingletonScope<IUserService, UserService>();
            BindInSingletonScope<IEmployeeRoleService, EmployeeRoleService>();

            Given(GetUsers.Default);
            Given(GetEmployees.Default);
            Given(GetEmployeeRoles.Default);
            Given(GetUserById.Default);
        }
        
        [When(@"Login is requested with properties")]
        public void WhenLoginIsRequestedWithProperties(Table table)
        {
            LoginView loginView = table.CreateInstance<LoginView>();
            try
            {
                Result = Kernel.Get<IUserService>().Login(loginView);
            }
            catch (Exception e)
            {
                ScenarioContext.Current.Add("Login_Exception", e);
            }
        }
        
        [Then(@"User is loginned")]
        public void ThenUserIsLoginned()
        {
            Assert.IsNotNull(Result);
        }

        [Then(@"User is not loginned with message")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThenUserIsNotLoginedWithMessage()
        {
            var exception = ScenarioContext.Current["Login_Exception"];
            Assert.IsNotNull(exception);
        }
    }
}
