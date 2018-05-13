using CP.ImportExport.Common.Contract;
using CP.ImportExport.Common.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.Common
{
    public class CommonModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IImportExportService>().To<ImportExportService>().InRequestScope();
            kernel.Bind<IImportExportResolverService>().To<ImportExportResolverService>().InRequestScope();
        }
    }
}