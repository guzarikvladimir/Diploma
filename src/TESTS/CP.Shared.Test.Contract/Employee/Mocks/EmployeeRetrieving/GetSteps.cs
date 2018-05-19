using System;
using System.Collections.Generic;
using AutoFixture;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Employee.Services;
using CP.SpecFlowEx.Test.Helpers;
using CP.SpecFlowEx.Test.Models;
using CP.SpecFlowEx.Test.Services;
using TechTalk.SpecFlow;

namespace CP.Shared.Test.Contract.Employee.Mocks.EmployeeRetrieving
{
    [Binding]
    public class GetSteps : ConfigurationStepsBase<Func<List<EmployeeView>>>
    {
        public const string Default = "IEmployeeRetrievingService.Get is configured";

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