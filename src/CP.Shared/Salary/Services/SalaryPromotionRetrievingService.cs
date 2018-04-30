using CP.Repository.Models;
using CP.Shared.Contract.Salary.Models;
using CP.Shared.Contract.Salary.Services;
using CP.Shared.Core.Services;

namespace CP.Shared.Salary.Services
{
    public class SalaryPromotionRetrievingService : 
        SimpleRetrievingService<SalaryPromotion, SalaryPromotionView>,
        ISalaryPromotionRetrievingService
    {
    }
}