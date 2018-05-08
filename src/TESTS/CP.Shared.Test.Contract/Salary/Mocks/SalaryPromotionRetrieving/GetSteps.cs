using System;
using System.Collections.Generic;
using AutoFixture;
using CP.Platform.Test.Core.Helpers;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Contract.Salary.Models;
using CP.Shared.Contract.Salary.Services;
using TechTalk.SpecFlow;

namespace CP.Shared.Test.Contract.Salary.Mocks.SalaryPromotionRetrieving
{
    [Binding]
    public class GetSteps : ConfigurationStepsBase<Func<IEnumerable<SalaryPromotionView>>>
    {
        public const string Default = @"ISalaryPromotionRetrievingService.Get is configured";

        public GetSteps(BaseTestData data) : base(data)
        {
            data.Mock<ISalaryPromotionRetrievingService>()
                .Setup(service => service.Get())
                .Returns(MockFunction.FunctionInvoker);
        }

        [Given(Default)]
        public void GivenDefault()
        {
            MockFunction.Set(() => Fixture.Create<List<SalaryPromotionView>>());
        }
    }
}