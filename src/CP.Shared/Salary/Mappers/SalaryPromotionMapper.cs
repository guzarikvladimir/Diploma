using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Repository.Models;
using CP.Shared.Contract.Salary.Models;

namespace CP.Shared.Salary.Mappers
{
    public class SalaryPromotionMapper : IEntityModifyingMapper<SalaryPromotionModel, SalaryPromotion>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<SalaryPromotionModel, SalaryPromotion>();
        }

        public void Map(SalaryPromotionModel viewModel, SalaryPromotion entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public SalaryPromotion Map(SalaryPromotionModel viewModel)
        {
            return Mapper.Map<SalaryPromotion>(viewModel);
        }
    }
}