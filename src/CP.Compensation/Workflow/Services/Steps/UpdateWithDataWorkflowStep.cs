using System;
using CP.Compensation.Workflow.Contract;
using CP.Platform.Identity.Contract;
using CP.Platform.Identity.Helpers;
using CP.Repository.Models;
using CP.Shared.Contract.CompensationPromotion.Models;
using Ninject;

namespace CP.Compensation.Workflow.Services.Steps
{
    public class UpdateWithDataWorkflowStep : ICompensationPromotionWorkflowStep
    {
        [Inject]
        IUserService UserService { get; set; }

        public void Update(CompensationPromotionModel model)
        {
            model.CreatedDate = DateTime.Now;
            model.CreatedById = UserService.Current.GetUserId();
            model.PromotionStatus = CompensationPromotionStatus.Approved;
            model.Comment = CompensationPromotionStatus.Approved.ToString();
        }
    }
}