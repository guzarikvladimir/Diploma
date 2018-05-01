using System.Collections.Generic;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Currency.Models;

namespace CP.Shared.Contract.Currency.Services
{
    public interface ICurrencyResolverService
    {
        CurrencyView GetResultCurrency(List<CompensationPromotionView> compensations);
    }
}