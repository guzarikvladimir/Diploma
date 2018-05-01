using System.Collections.Generic;
using System.Linq;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Core.Services;

namespace CP.Shared.Currency.Services
{
    public class CurrencyRetrievingService :
        SimpleRetrievingService<Repository.Models.Currency, CurrencyView>,
        ICurrencyRetrievingService
    {
        public List<CurrencyView> GetOrdered()
        {
            List<CurrencyView> currencies = Get().ToList();
            CurrencyView defaultCurrency = GetDefault();
            currencies.Remove(defaultCurrency);
            List<CurrencyView> orderedCurrencies = currencies.OrderBy(c => c.Name).ToList();
            orderedCurrencies.Insert(0, defaultCurrency);

            return orderedCurrencies;
        }

        public CurrencyView GetDefault()
        {
            return Get().First(c => c.Name == "USD");
        }
    }
}