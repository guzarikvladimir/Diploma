using CP.ImportExport.Location.Contract;
using CP.ImportExport.Location.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.Location
{
    public class LocationModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILocationImportExportService>().To<LocationImportExportService>().InRequestScope();
        }
    }
}