using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Repository.Models;
using CP.Shared.Contract.Bonus.Models;

namespace CP.Shared.Bonus.Mappers
{
    public class BonusPromotionMapper : IEntityModifyingMapper<BonusPromotionModel, BonusPromotion>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<BonusPromotionModel, BonusPromotion>();
        }

        public void Map(BonusPromotionModel viewModel, BonusPromotion entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public BonusPromotion Map(BonusPromotionModel viewModel)
        {
            return Mapper.Map<BonusPromotion>(viewModel);
        }
    }
}