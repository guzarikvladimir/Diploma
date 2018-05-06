using System;
using System.Collections.Generic;
using CP.Shared.Contract.Bonus.Models;

namespace CP.Shared.Contract.Bonus.Services
{
    public interface IBonusPromotionSerivce
    {
        List<BonusPromotionView> Get(Guid employeeId, bool onlyApproved = false);
    }
}