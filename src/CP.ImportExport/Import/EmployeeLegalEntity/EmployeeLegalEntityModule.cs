using CP.ImportExport.Import.EmployeeLegalEntity.Contract;
using CP.ImportExport.Import.EmployeeLegalEntity.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.Import.EmployeeLegalEntity
{
    public class EmployeeLegalEntityModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmployeeLegalEntityImportService>().To<EmployeeLegalEntityImportService>().InRequestScope();
        }
    }
}