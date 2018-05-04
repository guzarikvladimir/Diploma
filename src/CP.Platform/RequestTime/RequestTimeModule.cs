using CP.Platform.DependencyResolvers.Services;
using CP.Platform.RequestTime.Contract;
using CP.Platform.RequestTime.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.Platform.RequestTime
{
    public class RequestTimeModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IRequestTime>().To<Services.RequestTime>().InRequestScope();
        }
    }
}