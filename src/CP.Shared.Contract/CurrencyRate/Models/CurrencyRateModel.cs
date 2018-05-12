using System;
using CP.Platform.Crud.Models;
using CP.Repository.Models;

namespace CP.Shared.Contract.CurrencyRate.Models
{
    public class CurrencyRateModel : IEntityModel<Guid?>
    {
        public Guid? Id { get; set; }

        public Guid CurrencyId { get; set; }

        public decimal Ratio { get; set; }

        public CurrencyRateType Type { get; set; }

        public DateTime Date { get; set; }
    }
}