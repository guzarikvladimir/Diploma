using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.User.Models;
using CP.Shared.Test.Contract.User.Models;
using CP.SpecFlowEx.Test.Models;
using CP.SpecFlowEx.Test.Services;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CP.Shared.Test.Contract.User.Customiztions
{
    [Binding]
    public class UserViewSteps : EntityStepsBase<UserView>
    {
        public UserViewSteps(BaseTestData data) : base(data)
        {
        }

        [Given(@"Users are configured to have properties")]
        public void GivenUsersAreConfiguredToHaveProperties(Table table)
        {
            foreach (UserViewCustomizationModel model in table.CreateSet<UserViewCustomizationModel>())
            {
                UserView user = Fixture.Create<UserView>();
                user.Id = Fixture.Create<List<EmployeeView>>().Single(e => e.Email == model.Email).Id;
                user.Password = model.Password;
                list.Add(user);
            }
        }
    }
}