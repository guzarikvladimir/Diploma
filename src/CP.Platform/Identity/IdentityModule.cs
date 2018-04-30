using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Identity.Contract;
using CP.Platform.Identity.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.Platform.Identity
{
    public class IdentityModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
        }
    }
}