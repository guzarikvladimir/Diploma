using System;
using CP.Repository.Models;
using CP.Shared.Contract.Core.Models;
using CP.Shared.Contract.Currency.Models;

namespace CP.Shared.Contract.CurrencyRate.Models
{
    public class CurrencyRateView : IViewWithId<Guid>
    {
        public Guid Id { get; set; }

        public CurrencyView Currency { get; set; }

        public decimal Value { get; set; }

        public CurrencyRateType Type { get; set; }
    }
}