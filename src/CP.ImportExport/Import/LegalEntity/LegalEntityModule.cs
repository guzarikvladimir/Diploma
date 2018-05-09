using CP.ImportExport.Import.LegalEntity.Contract;
using CP.ImportExport.Import.LegalEntity.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.Import.LegalEntity
{
    public class LegalEntityModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILegalEntityImportService>().To<LegalEntityImportService>().InRequestScope();
        }
    }
}