using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Salary.Models;
using SalaryPromotionEntity = CP.Repository.Models.SalaryPromotion;

namespace CP.Shared.Salary.Mappers
{
    public class SalaryPromotionMapper : IEntityMapper<SalaryPromotionEntity, SalaryPromotionView>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<SalaryPromotionEntity, SalaryPromotionView>();
        }

        public SalaryPromotionView Map(SalaryPromotionEntity model)
        {
            return Mapper.Map<SalaryPromotionView>(model);
        }
    }
}