using AutoFixture;
using CP.Platform.Tests.Core.Services;
using Ninject.Web.Common;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebApi.Contract;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Tests.User.Services
{
    [Binding]
    public class RegisterSteps : StepsBase
    {
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
            view.Name = model.Name;
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
