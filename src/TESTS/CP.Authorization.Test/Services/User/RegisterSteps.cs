using AutoFixture;
using CP.Authorization.Contract.Models;
using CP.Authorization.Contract.Services;
using CP.Authorization.Services;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using Ninject.Web.Common;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CP.Authorization.Test.Services.User
{
    [Binding]
    public class RegisterSteps : StepsBase
    {
        public RegisterSteps(BaseTestData data) : base(data)
        {
        }

        [Given(@"Requestor is going to be registered")]
        public void GivenRequestorIsGoingToBeRegistered()
        {
            Kernel.Bind<IUserService>().To<UserService>().InRequestScope();
        }

        [Given(@"Requestor is configured to have properties")]
        public void GivenRequestorIsConfiguredToHaveProperties(Table table)
        {
            RegisterView model = table.CreateInstance<RegisterView>();
            RegisterView view = Fixture.Create<RegisterView>();
            view.Email = model.Email;
        }

        [When(@"Register is requested")]
        public void WhenRegisterIsRequested()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User is registered")]
        public void ThenUserIsRegistered()
        {
            ScenarioContext.Current.Pending();
        }
    }
}