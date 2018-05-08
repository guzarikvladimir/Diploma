using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.Platform.Test.Core.Helpers;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Contract.EmployeeToLegalEntity.Models;
using CP.Shared.Contract.EmployeeToLegalEntity.Services;
using Moq;
using TechTalk.SpecFlow;

namespace CP.Shared.Test.Contract.EmployeeToLegalEntity.Mocks.EmployeeToLeglEntityRetrieving
{
    [Binding]
    public class GetSteps : ConfigurationStepsBase<Func<Guid, bool, IEnumerable<EmployeeToLegalEntityView>>>
    {
        public const string Default = @"IEmployeeToLegalEntityRetrievingService.Get_employeeId_isActive is configured";

        public GetSteps(BaseTestData data) : base(data)
        {
            data.Mock<IEmployeeToLegalEntityRetrievingService>()
                .Setup(service => service.Get(It.IsAny<Guid>(), It.IsAny<bool>()))
                .Returns(MockFunction.FunctionInvoker);
        }

        [Given(Default)]
        public void GivenDefault()
        {
            MockFunction.Set((employeeId, isActive) => Fixture.Create<List<EmployeeToLegalEntityView>>()
                .Where(el => el.Employee.Id == employeeId && el.LegalEntity.IsActive));
        }
    }
}