using CP.Compensation.Workflow.Contract;
using CP.Compensation.Workflow.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.Compensation.Workflow
{
    public class WorkflowModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICompensationWorkflowService>().To<CompensationWorkflowService>().InRequestScope();
        }
    }
}