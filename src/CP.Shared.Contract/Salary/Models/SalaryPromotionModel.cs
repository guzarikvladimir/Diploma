using CP.Repository.Models;
using CP.Shared.Contract.CompensationPromotion.Models;

namespace CP.Shared.Contract.Salary.Models
{
    public class SalaryPromotionModel : CompensationPromotionModel
    {
        public SalaryType SalaryType { get; set; }
    }
}