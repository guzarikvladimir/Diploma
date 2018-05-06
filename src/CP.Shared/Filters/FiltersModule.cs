using CP.Platform.DependencyResolvers.Services;
using CP.Shared.Contract.Filters.Services;
using CP.Shared.Filters.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.Shared.Filters
{
    public class FiltersModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICompensationPromotionFilterService>()
                .To<CompensationPromotionFilterService>()
                .InRequestScope();
        }
    }
}