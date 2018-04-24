using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.Platform.Test.Core.Helpers;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Contract.EmployeeRole.Models;
using CP.Shared.Contract.EmployeeRole.Services;
using Moq;
using TechTalk.SpecFlow;

namespace CP.Shared.Test.Contract.EmployeeRole.Mocks.EmployeeRoleRetrieving
{
    [Binding]
    public class GetByEmployeeSteps : ConfigurationStepsBase<Func<Guid, List<EmployeeRoleView>>>
    {
        public const string Default = "IEmployeeRoleRetrievingService.GetByEmployee is configured";

        public GetByEmployeeSteps(BaseTestData data) : base(data)
        {
            data.Mock<IEmployeeRoleRetrievingService>()
                .Setup(service => service.GetByEmployee(It.IsAny<Guid>()))
                .Returns(MockFunction.FunctionInvoker);
        }

        [Given(Default)]
        public void GivenDefault()
        {
            MockFunction.Set((employeeId) => Fixture.Create<List<EmployeeRoleView>>()
                .Where(er => er.Employee.Id == employeeId)
                .ToList());
        }
    }
}