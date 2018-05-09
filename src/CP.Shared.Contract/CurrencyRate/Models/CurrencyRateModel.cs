using System;
using CP.Repository.Models;
using CP.Shared.Contract.Core.Models;

namespace CP.Shared.Contract.CurrencyRate.Models
{
    public class CurrencyRateModel : IModelWithId<Guid?>
    {
        public Guid? Id { get; set; }

        public Guid CurrencyId { get; set; }

        public decimal Ratio { get; set; }

        public CurrencyRateType Type { get; set; }

        public DateTime Date { get; set; }
    }
}