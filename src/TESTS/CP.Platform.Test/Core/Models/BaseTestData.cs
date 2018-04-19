using AutoFixture;
using Ninject;

namespace CP.Platform.Test.Core.Models
{
    public class BaseTestData : IBaseTestData
    {
        public IKernel Kernel { get; set; }

        public IFixture Fixture { get; set; }
    }
}