using System.Collections.Generic;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Employee.Models;

namespace CP.Compensation.Models
{
    public class CompensationView
    {
        public EmployeeView Employee { get; set; }

        public List<CompensationPromotionView> CompensationPromotions { get; set; }
    }
}