using CP.ImportExport.LegalEntity.Contract;
using CP.ImportExport.LegalEntity.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.LegalEntity
{
    public class LegalEntityModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILegalEntityImportExportService>().To<LegalEntityImportExportService>().InRequestScope();
        }
    }
}