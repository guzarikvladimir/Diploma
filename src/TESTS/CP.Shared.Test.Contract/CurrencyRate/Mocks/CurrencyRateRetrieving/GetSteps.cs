using System;
using System.Collections.Generic;
using AutoFixture;
using CP.Shared.Contract.CurrencyRate.Models;
using CP.Shared.Contract.CurrencyRate.Services;
using CP.SpecFlowEx.Test.Helpers;
using CP.SpecFlowEx.Test.Models;
using CP.SpecFlowEx.Test.Services;
using TechTalk.SpecFlow;

namespace CP.Shared.Test.Contract.CurrencyRate.Mocks.CurrencyRateRetrieving
{
    [Binding]
    public class GetSteps : ConfigurationStepsBase<Func<List<CurrencyRateView>>>
    {
        public const string Default = @"ICurrencyRateRetrievingService.Get is configured";

        public GetSteps(BaseTestData data) : base(data)
        {
            data.Mock<ICurrencyRateRetrievingService>()
                .Setup(service => service.Get())
                .Returns(MockFunction.FunctionInvoker);
        }

        [Given(Default)]
        public void GivenDefault()
        {
            MockFunction.Set(() => Fixture.Create<List<CurrencyRateView>>());
        }
    }
}