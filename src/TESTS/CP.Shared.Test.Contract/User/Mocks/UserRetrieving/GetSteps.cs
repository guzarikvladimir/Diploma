using System;
using System.Collections.Generic;
using AutoFixture;
using CP.Shared.Contract.User.Models;
using CP.Shared.Contract.User.Services;
using CP.SpecFlowEx.Test.Helpers;
using CP.SpecFlowEx.Test.Models;
using CP.SpecFlowEx.Test.Services;
using TechTalk.SpecFlow;

namespace CP.Shared.Test.Contract.User.Mocks.UserRetrieving
{
    [Binding]
    public class GetSteps : ConfigurationStepsBase<Func<List<UserView>>>
    {
        public const string Default = "IUserRetrievingService.Get is configured";

        public GetSteps(BaseTestData data) : base(data)
        {
            data.Mock<IUserRetrievingService>()
                .Setup(service => service.Get())
                .Returns(MockFunction.FunctionInvoker);
        }

        [Given(Default)]
        public void GivenDefault()
        {
            MockFunction.Set(() => Fixture.Create<List<UserView>>());
        }
    }
}