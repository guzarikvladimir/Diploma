using CP.ImportExport.EmployeeRole.Contract;
using CP.ImportExport.EmployeeRole.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.EmployeeRole
{
    public class EmployeeRoleModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmployeeRoleImportExportService>().To<EmployeeRoleImportExportService>().InRequestScope();
        }
    }
}