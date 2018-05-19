using System;
using System.Collections.Generic;
using AutoFixture;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Currency.Services;
using CP.SpecFlowEx.Test.Helpers;
using CP.SpecFlowEx.Test.Models;
using CP.SpecFlowEx.Test.Services;
using TechTalk.SpecFlow;

namespace CP.Shared.Test.Contract.Currency.Mocks.CurrencyRetrieving
{
    [Binding]
    public class GetSteps : ConfigurationStepsBase<Func<List<CurrencyView>>>
    {
        public const string Default = @"ICurrencyRetrievingService.Get is configured";

        public GetSteps(BaseTestData data) : base(data)
        {
            data.Mock<ICurrencyRetrievingService>()
                .Setup(service => service.Get())
                .Returns(MockFunction.FunctionInvoker);
        }

        [Given(Default)]
        public void GivenDefault()
        {
            MockFunction.Set(() => Fixture.Create<List<CurrencyView>>());
        }
    }
}