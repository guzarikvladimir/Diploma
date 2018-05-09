using CP.ImportExport.Import.EmployeeStatus.Contract;
using CP.ImportExport.Import.EmployeeStatus.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.Import.EmployeeStatus
{
    public class EmployeeStatusModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmployeeStatusImportService>().To<EmployeeStatusImportService>().InRequestScope();
        }
    }
}