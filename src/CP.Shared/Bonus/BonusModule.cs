using CP.Platform.DependencyResolvers.Services;
using CP.Shared.Bonus.Services;
using CP.Shared.Contract.Bonus.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.Shared.Bonus
{
    public class BonusModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IBonusPromotionRetrievingService>().To<BonusPromotionRetrievingService>().InRequestScope();
        }
    }
}