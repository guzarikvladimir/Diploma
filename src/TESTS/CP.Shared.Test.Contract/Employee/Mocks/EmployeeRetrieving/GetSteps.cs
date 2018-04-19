using System;
using System.Collections.Generic;
using AutoFixture;
using CP.Platform.Test.Core.Helpers;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Employee.Services;
using TechTalk.SpecFlow;

namespace CP.Shared.Test.Contract.Employee.Mocks.EmployeeRetrieving
{
    [Binding]
    public class GetSteps : ConfigurationStepsBase<Func<List<EmployeeView>>>
    {
        public const string Default = "IUserRetrievingService.Get is configured";

        public GetSteps(BaseTestData data) : base(data)
        {
            data.Mock<IEmployeeRetrievingService>()
                .Setup(service => service.Get())
                .Returns(MockFunction.FunctionInvoker);
        }

        [Given(Default)]
        public void GivenDefault()
        {
            MockFunction.Set(() => Fixture.Create<List<EmployeeView>>());
        }
    }
}