using System;
using System.Collections.Generic;
using AutoFixture;
using CP.Shared.Contract.EmployeeRole.Models;
using CP.Shared.Contract.EmployeeRole.Services;
using CP.SpecFlowEx.Test.Helpers;
using CP.SpecFlowEx.Test.Models;
using CP.SpecFlowEx.Test.Services;
using TechTalk.SpecFlow;

namespace CP.Shared.Test.Contract.EmployeeRole.Mocks.EmployeeRoleRetrieving
{
    [Binding]
    public class Get : ConfigurationStepsBase<Func<List<EmployeeRoleView>>>
    {
        public const string Default = "IEmployeeRoleRetrievingService.Get is configured";

        public Get(BaseTestData data) : base(data)
        {
            data.Mock<IEmployeeRoleRetrievingService>()
                .Setup(service => service.Get())
                .Returns(MockFunction.FunctionInvoker);
        }

        [Given(Default)]
        public void GivenDefault()
        {
            MockFunction.Set(() => Fixture.Create<List<EmployeeRoleView>>());
        }
    }
}