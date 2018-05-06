using System;
using CP.Shared.Contract.Compensation.Models;

namespace CP.Shared.Contract.Currency.Services
{
    public interface ICurrencyConverterService
    {
        ValueWithCurrency Convert(decimal value, Guid currencyFrom, Guid currencyTo, DateTime? date = null);

        ValueWithCurrency Add(ValueWithCurrency first, ValueWithCurrency second, Guid? currencyId = null);
    }
}