using System;
using System.Security.Claims;
using AutoMapper;
using CP.Authorization.Contract.Models;
using CP.Authorization.Contract.Services;
using CP.Authorization.Mappers;
using CP.Authorization.Services;
using CP.Platform.Db.Contract;
using CP.Platform.Db.Services;
using CP.Platform.Mappers.Contract;
using CP.Platform.Mappers.Services;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Contract.EmployeeRole.Services;
using CP.Shared.Contract.User.Services;
using CP.Shared.Employee.Mappers;
using CP.Shared.Employee.Services;
using CP.Shared.EmployeeRole.Services;
using CP.Shared.User.Mappers;
using CP.Shared.User.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Web.Common;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using GetEmployees = CP.Shared.Test.Contract.Employee.Mocks.EmployeeRetrieving.GetSteps;

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
            Kernel.Bind<IUserService>().To<UserService>().InRequestScope();
            Kernel.Bind<IUserRetrievingService>().To<UserRetrievingService>().InRequestScope();
            Given(GetEmployees.Default);
            Kernel.Bind<IEmployeeRetrievingService>().To<EmployeeRetrievingService>().InRequestScope();
            Kernel.Bind<IEmployeeRoleRetrievingService>().To<EmployeeRoleRetrievingService>().InRequestScope();
            Kernel.Bind<IUserModifyingService>().To<UserModifyingService>().InRequestScope();
            Kernel.Bind<IDbFactory>().To<DbFactory>().InRequestScope();
            Kernel.Bind(typeof(IEntityMapper<,>))
                .To(typeof(SimpleEntityMapper<,>))
                .InRequestScope();
            Kernel.Bind(typeof(IEntityModifyingMapper<,>))
                .To(typeof(SimpleEntityModifyingMapper<,>))
                .InRequestScope();

            Mapper.Initialize(config =>
            {
                EmployeeMapper.Register(config);
                UserMapper.Register(config);
                AuthorizationMapper.Register(config);
            });
        }
        
        [When(@"Login is requested with properties")]
        public void WhenLoginIsRequestedWithProperties(Table table)
        {
            LoginView loginView = table.CreateInstance<LoginView>();
            Result = Kernel.Get<IUserService>().Login(loginView);
        }
        
        [Then(@"User is loginned")]
        public void ThenUserIsLoginned()
        {
            Assert.IsNotNull(Result);
        }

        [Then(@"User is not loginned with message")]
        [ExpectedException(typeof(Exception))]
        public void ThenUserIsNotLoginedWithMessage()
        {
        }
    }
}
