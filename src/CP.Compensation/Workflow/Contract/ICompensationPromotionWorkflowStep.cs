using CP.Shared.Contract.CompensationPromotion.Models;

namespace CP.Compensation.Workflow.Contract
{
    public interface ICompensationPromotionWorkflowStep
    {
        void Update(CompensationPromotionModel model);
    }
}