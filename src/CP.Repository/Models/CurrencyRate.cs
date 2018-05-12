using System;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class CurrencyRate : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public Guid CurrencyId { get; set; }

        public DateTime Date { get; set; }

        public decimal Ratio { get; set; }

        public CurrencyRateType Type { get; set; }
    }
}