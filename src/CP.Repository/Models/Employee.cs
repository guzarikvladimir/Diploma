using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class Employee : IEntityWithId<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid StatusId { get; set; }

        public Guid LocationId { get; set; }

        public Guid JobFunctionId { get; set; }


        [ForeignKey("StatusId")]
        public virtual EmployeeStatus EmployeeStatus { get; set; }

        public virtual ICollection<CompensationPromotion> CompensationPromotions { get; set; }
    }
}