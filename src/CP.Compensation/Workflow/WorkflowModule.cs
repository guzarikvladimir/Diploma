using CP.Compensation.Workflow.Contract;
using CP.Compensation.Workflow.Services;
using CP.Compensation.Workflow.Services.Steps;
using CP.Compensation.Workflow.Services.Validators;
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

            kernel.Bind<ICompensationPromotionWorkflowStep>().To<UpdateWithDataWorkflowStep>().InRequestScope();

            kernel.Bind<ICompensationPromotionWorkflowValidator>().To<EmptyFieldsValidator>().InRequestScope();
            kernel.Bind<ICompensationPromotionWorkflowValidator>().To<PermissionsValidator>().InRequestScope();
        }
    }
}