using CP.Shared.Contract.Bonus.Models;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Salary.Models;

namespace CP.Compensation.Workflow.Contract
{
    public interface ICompensationWorkflowService
    {
        void Create(SalaryPromotionModel model);

        void Create(BonusPromotionModel model);

        void Reject(CompensationPromotionModel model);

    }
}