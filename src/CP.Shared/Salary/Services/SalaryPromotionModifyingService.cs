using CP.Platform.Crud.Services;
using CP.Repository.Models;
using CP.Shared.Contract.Salary.Models;
using CP.Shared.Contract.Salary.Services;

namespace CP.Shared.Salary.Services
{
    public class SalaryPromotionModifyingService :
        SimpleModifyingService<SalaryPromotion, SalaryPromotionModel>,
        ISalaryPromotionModifyingService
    {
    }
}