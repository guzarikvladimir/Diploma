using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.User.Models;
using CP.Shared.Test.Contract.User.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CP.Shared.Test.Contract.User.Customiztions
{
    [Binding]
    public class UserViewSteps : EntityStepsBase<UserView>
    {
        List<UserView> users = new List<UserView>();

        public UserViewSteps(BaseTestData data) : base(data)
        {
            Fixture.Register(() => users);
        }

        [Given(@"Users are configured to have properties")]
        public void GivenUsersAreConfiguredToHaveProperties(Table table)
        {
            foreach (UserViewCustomizationModel model in table.CreateSet<UserViewCustomizationModel>())
            {
                UserView user = Fixture.Create<UserView>();
                user.Id = Fixture.Create<List<EmployeeView>>().Single(e => e.Name == model.Name).Id;
                user.Password = model.Password;
                users.Add(user);
            }
        }
    }
}