using CP.ImportExport.EmployeeStatus.Contract;
using CP.ImportExport.EmployeeStatus.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.EmployeeStatus
{
    public class EmployeeStatusModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmployeeStatusImportExportService>().To<EmployeeStatusImportExportService>().InRequestScope();
        }
    }
}