using CP.ImportExport.Import.Core.Contract;
using CP.ImportExport.Import.Core.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;

namespace CP.ImportExport.Import.Core
{
    public class CoreModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IImportResolverService>().To<ImportResolverService>();
        }
    }
}