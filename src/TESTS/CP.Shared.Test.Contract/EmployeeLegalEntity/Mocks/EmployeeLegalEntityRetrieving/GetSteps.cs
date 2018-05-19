using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.Shared.Contract.EmployeeLegalEntity.Models;
using CP.Shared.Contract.EmployeeLegalEntity.Services;
using CP.SpecFlowEx.Test.Helpers;
using CP.SpecFlowEx.Test.Models;
using CP.SpecFlowEx.Test.Services;
using Moq;
using TechTalk.SpecFlow;

namespace CP.Shared.Test.Contract.EmployeeLegalEntity.Mocks.EmployeeLegalEntityRetrieving
{
    [Binding]
    public class GetSteps : ConfigurationStepsBase<Func<Guid, bool, IEnumerable<EmployeeLegalEntityView>>>
    {
        public const string Default = @"IEmployeeLegalEntityRetrievingService.Get_employeeId_isActive is configured";

        public GetSteps(BaseTestData data) : base(data)
        {
            data.Mock<IEmployeeLegalEntityRetrievingService>()
                .Setup(service => service.Get(It.IsAny<Guid>(), It.IsAny<bool>()))
                .Returns(MockFunction.FunctionInvoker);
        }

        [Given(Default)]
        public void GivenDefault()
        {
            MockFunction.Set((employeeId, isActive) => Fixture.Create<List<EmployeeLegalEntityView>>()
                .Where(el => el.Employee.Id == employeeId && el.LegalEntity.IsActive));
        }
    }
}