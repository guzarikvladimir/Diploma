using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.CompensationPromotion.Services;
using CP.Shared.Core.Services;

namespace CP.Shared.CompensationPromotion.Services
{
    public class CompensationPromotionRetrievingService :
        SimpleRetrievingService<Repository.Models.CompensationPromotion, CompensationPromotionView>,
        ICompensationPromotionRetrievingService
    {
    }
}