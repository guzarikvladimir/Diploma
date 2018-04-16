using CP.Platform.DependencyResolvers.Contract;
using CP.Platform.DependencyResolvers.Services;
using Ninject;

namespace CP.Platform.DependencyResolvers
{
    public class DependencyResolversModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IServiceAccessor>().To<ServiceAccessor>()
                .InSingletonScope()
                .WithConstructorArgument("kernel", kernel);
        }
    }
}