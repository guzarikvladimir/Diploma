using System;
using CP.Platform.RequestTime.Contract;
using CP.Platform.Test.Core.Helpers;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using TechTalk.SpecFlow;

namespace CP.Platform.Test.RequestTime.Mocks.RequestTime
{
    [Binding]
    public class TimeSteps : ConfigurationStepsBase<Func<DateTime>>
    {
        public TimeSteps(BaseTestData data) : base(data)
        {
            data.Mock<IRequestTime>()
                .Setup(service => service.Time)
                .Returns(MockFunction.FunctionInvoker);
        }

        [Given("Request time is configured to be (.*)")]
        public void GetDefault(string date)
        {
            MockFunction.Set(() => HelperService.ParseDate(date));
        }
    }
}