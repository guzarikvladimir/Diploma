using System;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class SalaryPromotion : IEntityWithId<Guid>
    {
        public Guid Id { get; set; }
        
        public SalaryType SalaryType { get; set; }
    }
}