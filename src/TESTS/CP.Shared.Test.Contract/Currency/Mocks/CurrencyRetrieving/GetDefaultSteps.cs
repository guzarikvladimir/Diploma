using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.Platform.Test.Core.Helpers;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Currency.Services;
using TechTalk.SpecFlow;

namespace CP.Shared.Test.Contract.Currency.Mocks.CurrencyRetrieving
{
    [Binding]
    public class GetDefaultSteps : ConfigurationStepsBase<Func<CurrencyView>>
    {
        public const string Default = @"ICurrencyRetrievingService.GetDefault is configured";

        public GetDefaultSteps(BaseTestData data) : base(data)
        {
            //data.Mock<ICurrencyRetrievingService>()
            //    .Setup(service => service.GetDefault())
            //    .Returns(MockFunction.FunctionInvoker);
        }

        [Given(Default)]
        public void FivenDefault()
        {
            MockFunction.Set(() => Fixture.Create<List<CurrencyView>>()
            .First(c => c.Name.ToLower() == "usd"));
        }
    }
}