using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Currency.Services;
using CP.SpecFlowEx.Test.Helpers;
using CP.SpecFlowEx.Test.Models;
using CP.SpecFlowEx.Test.Services;
using Moq;
using TechTalk.SpecFlow;

namespace CP.Shared.Test.Contract.Currency.Mocks.CurrencyRetrieving
{
    [Binding]
    public class GetByIdSteps : ConfigurationStepsBase<Func<Guid, CurrencyView>>
    {
        public const string Default = @"ICurrencyRetrievingService.GetById is configured";

        public GetByIdSteps(BaseTestData data) : base(data)
        {
            data.Mock<ICurrencyRetrievingService>()
                .Setup(service => service.GetById(It.IsAny<Guid>()))
                .Returns(MockFunction.FunctionInvoker);
        }

        [Given(Default)]
        public void GivenDefault()
        {
            MockFunction.Set((currencyId) => Fixture.Create<List<CurrencyView>>()
                .FirstOrDefault(c => c.Id == currencyId));
        }
    }
}