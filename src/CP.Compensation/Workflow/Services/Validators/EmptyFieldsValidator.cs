using System;
using CP.Compensation.Workflow.Contract;
using CP.Shared.Contract.CompensationPromotion.Models;

namespace CP.Compensation.Workflow.Services.Validators
{
    public class EmptyFieldsValidator : ICompensationPromotionWorkflowValidator
    {
        public void Validate(CompensationPromotionModel model)
        {
            if (model.Value == 0)
            {
                throw new ArgumentException("Value cannot be 0.");
            }
        }
    }
}