using System;
using System.ComponentModel.DataAnnotations.Schema;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class CompensationPromotion : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public decimal Value { get; set; }

        public Guid CurrencyId { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid LegalEntityId { get; set; }

        public CompensationPromotionType PromotionType { get; set; }

        public CompensationPromotionStatus PromotionStatus { get; set; }

        public DateTime ApplyDate { get; set; }
        
        public Guid CreatedById { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Comment { get; set; }


        [ForeignKey("CreatedById")]
        [InverseProperty("CreatedCompensationPromotions")]
        public virtual Employee CreatedByEmployee { get; set; }
    }
}