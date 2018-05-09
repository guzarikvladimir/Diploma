using CP.ImportExport.Import.Employee.Contract;
using CP.ImportExport.Import.Employee.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.Import.Employee
{
    public class EmployeeModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmployeeImportService>().To<EmployeeImportService>().InRequestScope();
        }
    }
}