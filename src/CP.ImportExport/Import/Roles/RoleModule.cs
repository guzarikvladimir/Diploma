using CP.ImportExport.Import.Roles.Contract;
using CP.ImportExport.Import.Roles.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.Import.Roles
{
    public class RoleModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IRoleImportService>().To<RoleImportService>().InRequestScope();
        }
    }
}