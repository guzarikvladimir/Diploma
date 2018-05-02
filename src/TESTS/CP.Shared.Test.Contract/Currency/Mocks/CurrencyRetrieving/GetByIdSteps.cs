using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.Platform.Test.Core.Helpers;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Currency.Services;
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