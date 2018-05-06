using CP.Shared.Contract.Currency.Models;

namespace CP.Shared.Contract.Compensation.Models
{
    public class ValueWithCurrency
    {
        public decimal Value { get; set; }

        public CurrencyView Currency { get; set; }

        public ValueWithCurrency(decimal value, CurrencyView currency)
        {
            Value = value;
            Currency = currency;
        }

        public ValueWithCurrency Add(ValueWithCurrency other)
        {
            return new ValueWithCurrency(Value + other.Value, Currency);
        }
    }
}