using System;
using CP.Shared.Contract.Compensation.Models;
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

        public ValueWithCurrency Convert(decimal value, Guid currencyFrom, Guid currencyTo, DateTime? date = null)
        {
            CurrencyRateView rateFrom = CurrencyRateService.Get(currencyFrom, date);
            CurrencyRateView rateTo = CurrencyRateService.Get(currencyTo, date);
            decimal resultValue = value / rateFrom.Ratio * rateTo.Ratio;

            return new ValueWithCurrency(resultValue, CurrencyRetrievingService.GetById(currencyTo));
        }

        public ValueWithCurrency Add(ValueWithCurrency first, ValueWithCurrency second, Guid? currencyId = null)
        {
            if (first == null)
            {
                return second;
            }

            if (first.Currency.Id == second.Currency.Id)
            {
                return first.Add(second);
            }

            if (currencyId.HasValue)
            {
                ValueWithCurrency firstConverted = Convert(first.Value, first.Currency.Id, currencyId.Value);
                ValueWithCurrency secondConverted = Convert(second.Value, second.Currency.Id, currencyId.Value);

                return firstConverted.Add(secondConverted);
            }

            ValueWithCurrency secondToFirst = Convert(second.Value, second.Currency.Id, first.Currency.Id);

            return first.Add(secondToFirst);
        }
    }
}