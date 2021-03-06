﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.Platform.Test.Core.Helpers;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Contract.User.Models;
using CP.Shared.Contract.User.Services;
using Moq;
using TechTalk.SpecFlow;

namespace CP.Shared.Test.Contract.User.Mocks.UserRetrieving
{
    [Binding]
    public class GetByIdSteps : ConfigurationStepsBase<Func<Guid, UserView>>
    {
        public const string Default = "IUserRetrievingService.GetById is configured";

        public GetByIdSteps(BaseTestData data) : base(data)
        {
            data.Mock<IUserRetrievingService>()
                .Setup(service => service.GetById(It.IsAny<Guid>()))
                .Returns(MockFunction.FunctionInvoker);
        }

        [Given(Default)]
        public void GivenDefault()
        {
            MockFunction.Set((userId) => Fixture.Create<List<UserView>>()
                .FirstOrDefault(u => u.Id == userId));
        }
    }
}