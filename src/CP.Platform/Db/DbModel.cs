using CP.Platform.Db.Contract;
using CP.Platform.Db.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.Platform.Db
{
    public class DbModel : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDbContextScopeFactory>().To<DbContextScopeFactory>().InRequestScope();
        }
    }
}