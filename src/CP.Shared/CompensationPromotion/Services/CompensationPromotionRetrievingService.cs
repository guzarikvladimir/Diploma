using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.CompensationPromotion.Services;
using CP.Shared.Core.Services;
using CompensationPromotionEntity = CP.Repository.Models.CompensationPromotion;

namespace CP.Shared.CompensationPromotion.Services
{
    public class CompensationPromotionRetrievingService :
        SimpleRetrievingService<CompensationPromotionEntity, CompensationPromotionView>,
        ICompensationPromotionRetrievingService
    {
    }
}