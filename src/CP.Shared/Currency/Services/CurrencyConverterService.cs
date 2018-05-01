using System;
using CP.Shared.Contract.Compensation.Models;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Contract.CurrencyRate.Models;
using CP.Shared.Contract.CurrencyRate.Services;
using Ninject;

namespace CP.Shared.Currency.Services
{
    public class CurrencyConverterService : ICurrencyConverterService
    {
        #region Injects

        [Inject]
        ICurrencyRateService CurrencyRateService { get; set; }

        [Inject]
        ICurrencyRetrievingService CurrencyRetrievingService { get; set; }

        #endregion

        public ValueWithCurrency Convert(CompensationPromotionView compensation, Guid currencyId, 
            DateTime? date = null)
        {
            CurrencyRateView rateFrom = CurrencyRateService.Get(compensation.Currency.Id, date);
            CurrencyRateView rateTo = CurrencyRateService.Get(currencyId, date);
            decimal value = compensation.Value / rateFrom.Ratio * rateTo.Ratio;

            return new ValueWithCurrency()
            {
                Value = value,
                Currency = CurrencyRetrievingService.GetById(currencyId)
            };
        }
    }
}