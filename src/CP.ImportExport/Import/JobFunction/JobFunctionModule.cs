using CP.ImportExport.Import.JobFunction.Contract;
using CP.ImportExport.Import.JobFunction.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.Import.JobFunction
{
    public class JobFunctionModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IJobFunctionImportService>().To<JobFunctionImportService>().InRequestScope();
        }
    }
}