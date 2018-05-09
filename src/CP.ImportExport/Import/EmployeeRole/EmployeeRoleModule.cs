using CP.ImportExport.Import.EmployeeRole.Contract;
using CP.ImportExport.Import.EmployeeRole.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.Import.EmployeeRole
{
    public class EmployeeRoleModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmployeeRoleImportService>().To<EmployeeRoleImportService>().InRequestScope();
        }
    }
}