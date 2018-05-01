using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Repository.Models;
using CP.Shared.Contract.Bonus.Models;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.CompensationPromotion.Services;
using Ninject;

namespace CP.Shared.Bonus.Mappers
{
    public class BonusPromotionMapper : 
        IEntityMapper<BonusPromotion, BonusPromotionView>,
        IEntityModifyingMapper<BonusPromotionModel, BonusPromotion>
    {
        [Inject]
        ICompensationPromotionRetrievingService CompensationPromotionRetrievingService { get; set; }

        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<BonusPromotionModel, BonusPromotion>();
            config.CreateMap<BonusPromotion, BonusPromotionView>();
            config.CreateMap<CompensationPromotionView, BonusPromotionView>();
        }

        public BonusPromotionView Map(BonusPromotion model)
        {
            CompensationPromotionView compensation = CompensationPromotionRetrievingService.GetById(model.Id);
            BonusPromotionView bonus = Mapper.Map<BonusPromotionView>(compensation);

            return Mapper.Map(model, bonus);
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