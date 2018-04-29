using System;
using System.Collections.Generic;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Core.Services;

namespace CP.Shared.Contract.CompensationPromotion.Services
{
    public interface ICompensationPromotionRetrievingService : ISimpleRetrievingService<CompensationPromotionView>
    {
        IEnumerable<CompensationPromotionView> GetByEmployee(Guid employeeId);
    }
}