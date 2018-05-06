using System;
using CP.Repository.Models;
using CP.Shared.Contract.Core.Models;

namespace CP.Shared.Contract.CompensationPromotion.Models
{
    public class CompensationPromotionModel : IModelWithId<Guid?>
    {
        public Guid? Id { get; set; }

        public decimal Value { get; set; }

        public Guid CurrencyId { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid LegalEntityId { get; set; }

        public CompensationPromotionType PromotionType { get; set; }

        public CompensationPromotionStatus PromotionStatus { get; set; }

        public DateTime ApplyDate { get; set; }

        public string Comment { get; set; }

        public Guid CreatedById { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}