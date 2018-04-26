using System;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class CompensationPromotion : IEntityWithId<Guid>
    {
        public Guid Id { get; set; }

        public decimal Value { get; set; }

        public Guid CurrencyId { get; set; }

        public Guid EmployeeId { get; set; }

        public CompensationPromotionType PromotionType { get; set; }
    }
}