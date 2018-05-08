using System;
using System.Collections.Generic;
using AutoFixture;
using CP.Platform.Test.Core.Helpers;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Contract.Bonus.Models;
using CP.Shared.Contract.Bonus.Services;
using TechTalk.SpecFlow;

namespace CP.Shared.Test.Contract.Bonus.Mocks.BonusPromotionRetrieving
{
    [Binding]
    public class GetSteps : ConfigurationStepsBase<Func<IEnumerable<BonusPromotionView>>>
    {
        public const string Default = @"IBonusPromotionRetrievingService.Get is configured";

        public GetSteps(BaseTestData data) : base(data)
        {
            data.Mock<IBonusPromotionRetrievingService>()
                .Setup(service => service.Get())
                .Returns(MockFunction.FunctionInvoker);
        }

        [Given(Default)]
        public void Given()
        {
            MockFunction.Set(() => Fixture.Create<List<BonusPromotionView>>());
        }
    }
}