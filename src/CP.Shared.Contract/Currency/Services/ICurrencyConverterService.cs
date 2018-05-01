using System;
using CP.Shared.Contract.Compensation.Models;
using CP.Shared.Contract.CompensationPromotion.Models;

namespace CP.Shared.Contract.Currency.Services
{
    public interface ICurrencyConverterService
    {
        ValueWithCurrency Convert(CompensationPromotionView compensation, Guid currencyId, DateTime? date = null);
    }
}