using CP.ImportExport.JobFunction.Contract;
using CP.ImportExport.JobFunction.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.JobFunction
{
    public class JobFunctionModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IJobFunctionImportExportService>().To<JobFunctionImportExportService>().InRequestScope();
        }
    }
}