using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Platform.Mappers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.Platform.Mappers
{
    public class MappersModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IEntityMapper<,>))
                .To(typeof(SimpleEntityMapper<,>))
                .InRequestScope();
            kernel.Bind(typeof(IEntityModifyingMapper<,>))
                .To(typeof(SimpleEntityModifyingMapper<,>))
                .InRequestScope();
        }
    }
}