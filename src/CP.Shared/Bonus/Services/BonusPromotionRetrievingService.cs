using CP.Repository.Models;
using CP.Shared.Contract.Bonus.Models;
using CP.Shared.Contract.Bonus.Services;
using CP.Shared.Core.Services;

namespace CP.Shared.Bonus.Services
{
    public class BonusPromotionRetrievingService : 
        SimpleRetrievingService<BonusPromotion, BonusPromotionView>,
        IBonusPromotionRetrievingService
    {
    }
}