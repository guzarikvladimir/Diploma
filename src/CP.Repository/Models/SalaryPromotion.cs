using System;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class SalaryPromotion : IEntity<Guid>
    {
        public Guid Id { get; set; }
        
        public SalaryType SalaryType { get; set; }
    }
}