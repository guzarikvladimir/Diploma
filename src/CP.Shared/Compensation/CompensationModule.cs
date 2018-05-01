using CP.Platform.DependencyResolvers.Services;
using CP.Shared.Compensation.Services;
using CP.Shared.Contract.Compensation.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.Shared.Compensation
{
    public class CompensationModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICompensationCalculationService>().To<CompensationCalculationService>().InRequestScope();
        }
    }
}