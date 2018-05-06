using System.Collections.Generic;
using System.Linq;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Currency.Services;
using Ninject;

namespace CP.Shared.Currency.Services
{
    public class CurrencyService : ICurrencyService
    {
        [Inject]
        ICurrencyRetrievingService CurrencyRetrievingService { get; set; }

        public List<CurrencyView> GetOrdered()
        {
            List<CurrencyView> currencies = CurrencyRetrievingService.Get().ToList();
            CurrencyView defaultCurrency = GetDefault();
            currencies.Remove(defaultCurrency);
            List<CurrencyView> orderedCurrencies = currencies.OrderBy(c => c.Name).ToList();
            orderedCurrencies.Insert(0, defaultCurrency);

            return orderedCurrencies;
        }

        public CurrencyView GetDefault()
        {
            return CurrencyRetrievingService.Get().First(c => c.Name == "USD");
        }
    }
}