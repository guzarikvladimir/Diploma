using AutoFixture;
using CP.Platform.Test.Core.Models;
using Ninject;
using TechTalk.SpecFlow;

namespace CP.Platform.Test.Core.Services
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
                //data.Kernel = new MoqMockingKernel(ninjectSettings);
                data.Kernel = new StandardKernel(ninjectSettings);

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