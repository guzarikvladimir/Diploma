using System;
using CP.Platform.Crud.Models;

namespace CP.Shared.Contract.LegalEntity.Models
{
    public class LegalEntityModel : IEntityModel<Guid?>
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public Guid CurrencyId { get; set; }

        public bool IsActive { get; set; }
    }
}