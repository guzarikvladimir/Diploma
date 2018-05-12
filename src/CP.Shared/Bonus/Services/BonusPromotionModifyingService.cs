using CP.Platform.Crud.Services;
using CP.Repository.Models;
using CP.Shared.Contract.Bonus.Models;
using CP.Shared.Contract.Bonus.Services;

namespace CP.Shared.Bonus.Services
{
    public class BonusPromotionModifyingService :
        SimpleModifyingService<BonusPromotion, BonusPromotionModel>,
        IBonusPromotionModifyingService
    {
    }
}