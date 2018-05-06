using System;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Filters.Model;

namespace CP.Shared.Contract.Filters.Services
{
    public interface ICompensationPromotionFilterService
    {
        Func<CompensationPromotionView, bool> Get(CollectionViewParameters parameters);
    }
}