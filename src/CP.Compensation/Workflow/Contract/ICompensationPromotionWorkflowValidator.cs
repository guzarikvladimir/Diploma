using CP.Shared.Contract.CompensationPromotion.Models;

namespace CP.Compensation.Workflow.Contract
{
    public interface ICompensationPromotionWorkflowValidator
    {
        void Validate(CompensationPromotionModel model);
    }
}