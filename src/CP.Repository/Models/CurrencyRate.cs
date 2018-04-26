using System;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class CurrencyRate : IEntityWithId<Guid>
    {
        public Guid Id { get; set; }

        public Guid CurrencyId { get; set; }

        public decimal Value { get; set; }

        public CurrencyRateType Type { get; set; }
    }
}