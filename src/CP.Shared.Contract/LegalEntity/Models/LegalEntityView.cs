using System;
using CP.Shared.Contract.Core.Models;
using CP.Shared.Contract.Currency.Models;

namespace CP.Shared.Contract.LegalEntity.Models
{
    public class LegalEntityView : IViewWithId<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public CurrencyView Currency { get; set; }

        public bool IsActive { get; set; }
    }
}