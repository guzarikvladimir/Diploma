using AutoFixture;
using CP.SpecFlowEx.Test.Models;
using Ninject;
using Ninject.MockingKernel.Moq;
using TechTalk.SpecFlow;

namespace CP.SpecFlowEx.Test.Services
{
    public abstract class StepsBase : Steps
    {
        protected BaseTestData data;
        protected IFixture Fixture => data.Fixture;
        protected IKernel Kernel => data.Kernel;

        public StepsBase(BaseTestData data)
        {
            this.data = data;
            if (data.Kernel == null)
            {
                var ninjectSettings = new NinjectSettings { AllowNullInjection = true, InjectNonPublic = true };
                data.Kernel = new MoqMockingKernel(ninjectSettings);

                data.Fixture = new Fixture();
                data.Kernel.Bind<IFixture>().ToConstant(data.Fixture).InSingletonScope();
            }
        }

        protected void BindInSingletonScope<TFrom, TTo>() where TTo : TFrom
        {
            Kernel.Bind<TFrom>().To<TTo>().InSingletonScope();
        }
    }
}