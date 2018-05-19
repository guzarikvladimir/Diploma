using AutoFixture;
using Ninject;

namespace CP.SpecFlowEx.Test.Models
{
    public interface IBaseTestData
    {
        IKernel Kernel { get; }

        IFixture Fixture { get; }
    }
}