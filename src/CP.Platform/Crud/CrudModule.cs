using CP.Platform.Crud.Contract;
using CP.Platform.Crud.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;

namespace CP.Platform.Crud
{
    public class CrudModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IMemoryStorage<>)).To(typeof(MemoryStorage<>)).InSingletonScope();
        }
    }
}