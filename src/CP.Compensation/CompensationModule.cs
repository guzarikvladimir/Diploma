using CP.Compensation.Contract.Services;
using CP.Compensation.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.Compensation
{
    public class CompensationModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICompensationTableSerivce>().To<CompensationTableSerivce>().InRequestScope();
            kernel.Bind<ICompensationWorkflowService>().To<CompensationWorkflowService>().InRequestScope();
            kernel.Bind<ICompensationSidePanelService>().To<CompensationSidePanelService>().InRequestScope();
        }
    }
}