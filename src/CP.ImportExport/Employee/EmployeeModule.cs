using CP.ImportExport.Employee.Contract;
using CP.ImportExport.Employee.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.Employee
{
    public class EmployeeModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmployeeImportExportService>().To<EmployeeImportExportService>().InRequestScope();
        }
    }
}