using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.CompensationPromotion.Mappers;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Salary.Services;
using CP.Shared.Salary.Mappers;
using CP.Shared.Salary.Services;
using Ninject;
using Ninject.Web.Common;
using CompensationPromotionEntity = CP.Repository.Models.CompensationPromotion;

namespace CP.Shared.Salary
{
    public class SalaryModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISalaryPromotionRetrievingService>().To<SalaryPromotionRetrievingService>().InRequestScope();

            kernel.Bind<IEntityMapper<CompensationPromotionEntity, CompensationPromotionView>>()
                .To<CompensationPromotionMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            SalaryPromotionMapper.Register(config);
        }
    }
}