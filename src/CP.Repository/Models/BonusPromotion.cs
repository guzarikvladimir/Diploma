using System;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class BonusPromotion : IEntityWithId<Guid>
    {
        public Guid Id { get; set; }
    }
}