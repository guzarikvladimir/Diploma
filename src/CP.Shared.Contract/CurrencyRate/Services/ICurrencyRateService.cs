using System;
using CP.Shared.Contract.CurrencyRate.Models;

namespace CP.Shared.Contract.CurrencyRate.Services
{
    public interface ICurrencyRateService
    {
        CurrencyRateView Get(Guid currencyId, DateTime? date = null);
    }
}