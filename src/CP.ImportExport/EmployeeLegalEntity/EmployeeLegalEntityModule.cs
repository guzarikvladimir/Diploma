using CP.ImportExport.EmployeeLegalEntity.Contract;
using CP.ImportExport.EmployeeLegalEntity.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.EmployeeLegalEntity
{
    public class EmployeeLegalEntityModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmployeeLegalEntityImportExportService>().To<EmployeeLegalEntityImportExportService>().InRequestScope();
        }
    }
}