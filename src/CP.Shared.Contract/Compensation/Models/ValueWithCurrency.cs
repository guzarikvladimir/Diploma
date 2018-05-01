using CP.Shared.Contract.Currency.Models;

namespace CP.Shared.Contract.Compensation.Models
{
    public class ValueWithCurrency
    {
        public decimal Value { get; set; }

        public CurrencyView Currency { get; set; }
    }
}