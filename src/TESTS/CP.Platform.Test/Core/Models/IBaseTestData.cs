using AutoFixture;
using Ninject;

namespace CP.Platform.Test.Core.Models
{
    public interface IBaseTestData
    {
        IKernel Kernel { get; }

        IFixture Fixture { get; }
    }
}