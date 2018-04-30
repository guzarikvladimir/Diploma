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
            kernel.Bind<ICompensationSerivce>().To<CompensationSerivce>().InRequestScope();
            kernel.Bind<ICompensationWorkflowService>().To<CompensationWorkflowService>().InRequestScope();
        }
    }
}