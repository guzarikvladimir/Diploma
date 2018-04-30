using System.Collections.Generic;
using CP.Shared.Contract.Currency.Models;

namespace CP.Shared.Contract.Currency.Services
{
    public interface ICurrencyService
    {
        List<CurrencyView> GetOrdered();

        CurrencyView GetDefault();
    }
}