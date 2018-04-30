using CP.Shared.Contract.CompensationPromotion.Models;

namespace CP.Compensation.Contract.Services
{
    public interface ICompensationWorkflowService
    {
        void Create(CompensationPromotionModel model);
    }
}