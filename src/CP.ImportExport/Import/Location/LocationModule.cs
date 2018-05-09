using CP.ImportExport.Import.Location.Contract;
using CP.ImportExport.Import.Location.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.Import.Location
{
    public class LocationModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILocationImportService>().To<LocationImportService>().InRequestScope();
        }
    }
}