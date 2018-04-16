using AutoFixture;
using Ninject;

namespace CP.Platform.Tests.Core.Services
{
    public abstract class StepsBase
    {
        public IFixture Fixture { get; }

        public IKernel Kernel { get; }

        protected StepsBase()
        {
            Fixture = new Fixture();
            Kernel = new StandardKernel();
        }
    }
}