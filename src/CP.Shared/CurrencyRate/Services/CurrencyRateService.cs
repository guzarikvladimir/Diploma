using System;
using System.Collections.Generic;
using System.Linq;
using CP.Platform.Helpers;
using CP.Platform.RequestTime.Contract;
using CP.Repository.Models;
using CP.Shared.Contract.CurrencyRate.Models;
using CP.Shared.Contract.CurrencyRate.Services;
using Ninject;

namespace CP.Shared.CurrencyRate.Services
{
    public class CurrencyRateService : ICurrencyRateService
    {
        #region Injects

        [Inject]
        ICurrencyRateRetrievingService CurrencyRateRetrievingService { get; set; }

        [Inject]
        IRequestTime RequestTime { get; set; }

        #endregion

        public CurrencyRateView Get(Guid currencyId, DateTime? date = null)
        {
            IEnumerable<CurrencyRateView> currencyRates = CurrencyRateRetrievingService.Get()
                .Where(cr => cr.Currency.Id == currencyId)
                .OrderByDescending(cr => cr.Date);
            CurrencyRateView currencyRate = date.HasValue
                ? currencyRates.Where(cr => cr.Type == CurrencyRateType.Monthly)
                    .FirstOrDefault(cr => cr.Date <= date.Value.ToUpperDate())
                : currencyRates.Where(cr => cr.Type == CurrencyRateType.Daily)
                    .FirstOrDefault(cr => cr.Date <= RequestTime.Time);

            return currencyRate;
        }
    }
}