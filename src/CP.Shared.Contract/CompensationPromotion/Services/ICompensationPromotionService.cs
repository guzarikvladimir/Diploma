using System;
using System.Collections.Generic;
using CP.Shared.Contract.CompensationPromotion.Models;

namespace CP.Shared.Contract.CompensationPromotion.Services
{
    public interface ICompensationPromotionService
    {
        List<CompensationPromotionView> Get(Guid employeeId);
    }
}