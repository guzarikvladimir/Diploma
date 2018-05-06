using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Repository.Models;
using CP.Shared.Contract.Salary.Models;
using CP.Shared.Contract.Salary.Services;
using CP.Shared.Salary.Mappers;
using CP.Shared.Salary.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.Shared.Salary
{
    public class SalaryModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISalaryPromotionRetrievingService>().To<SalaryPromotionRetrievingService>().InRequestScope();
            kernel.Bind<ISalaryPromotionModifyingService>().To<SalaryPromotionModifyingService>().InRequestScope();
            kernel.Bind<ISalaryPromotionService>().To<SalaryPromotionService>().InRequestScope();

            kernel.Bind<IEntityModifyingMapper<SalaryPromotionModel, SalaryPromotion>,
                    IEntityMapper<SalaryPromotion, SalaryPromotionView>>()
                .To<SalaryPromotionMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            SalaryPromotionMapper.Register(config);
        }
    }
}