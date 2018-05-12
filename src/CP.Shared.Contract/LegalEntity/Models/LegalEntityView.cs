using System;
using CP.Platform.Crud.Models;
using CP.Shared.Contract.Currency.Models;

namespace CP.Shared.Contract.LegalEntity.Models
{
    public class LegalEntityView : IEntityView<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public CurrencyView Currency { get; set; }

        public bool IsActive { get; set; }
    }
}