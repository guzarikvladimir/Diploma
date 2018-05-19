using AutoFixture;
using Ninject;

namespace CP.SpecFlowEx.Test.Models
{
    public class BaseTestData : IBaseTestData
    {
        public IKernel Kernel { get; set; }

        public IFixture Fixture { get; set; }
    }
}