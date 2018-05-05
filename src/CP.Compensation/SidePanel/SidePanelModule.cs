using CP.Compensation.SidePanel.Contract;
using CP.Compensation.SidePanel.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.Compensation.SidePanel
{
    public class SidePanelModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICompensationSidePanelService>().To<CompensationSidePanelService>().InRequestScope();
        }
    }
}