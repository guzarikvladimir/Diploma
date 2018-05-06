using System;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class LegalEntity : IEntityWithId<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CurrencyId { get; set; }

        public bool IsActive { get; set; }
    }
}