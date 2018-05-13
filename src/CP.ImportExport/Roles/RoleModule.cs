using CP.ImportExport.Roles.Contract;
using CP.ImportExport.Roles.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.Roles
{
    public class RoleModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IRoleImportExportService>().To<RoleImportExportService>().InRequestScope();
        }
    }
}