using System;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class BonusPromotion : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}