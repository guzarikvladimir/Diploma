using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.CompensationPromotion.Mappers;
using CP.Shared.CompensationPromotion.Services;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.CompensationPromotion.Services;
using Ninject;
using Ninject.Web.Common;
using CompensationPromotionEntity = CP.Repository.Models.CompensationPromotion;

namespace CP.Shared.CompensationPromotion
{
    public class CompensationPromotionModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICompensationPromotionRetrievingService>()
                .To<CompensationPromotionRetrievingService>()
                .InRequestScope();

            kernel.Bind<IEntityMapper<CompensationPromotionEntity, CompensationPromotionView>>()
                .To<CompensationPromotionMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            CompensationPromotionMapper.Register(config);
        }
    }
}