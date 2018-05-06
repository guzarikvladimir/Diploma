using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Repository.Models;
using CP.Shared.Bonus.Mappers;
using CP.Shared.Bonus.Services;
using CP.Shared.Contract.Bonus.Models;
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
            kernel.Bind<IBonusPromotionModifyingService>().To<BonusPromotionModifyingService>().InRequestScope();
            kernel.Bind<IBonusPromotionSerivce>().To<BonusPromotionSerivce>().InRequestScope();

            kernel.Bind<IEntityModifyingMapper<BonusPromotionModel, BonusPromotion>,
                    IEntityMapper<BonusPromotion, BonusPromotionView>>()
                .To<BonusPromotionMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            BonusPromotionMapper.Register(config);
        }
    }
}