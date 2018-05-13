using System.Collections.Generic;
using CP.Compensation.Workflow.Contract;
using CP.Platform.Db.Contract;
using CP.Repository.Models;
using CP.Shared.Contract.Bonus.Models;
using CP.Shared.Contract.Bonus.Services;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.CompensationPromotion.Services;
using CP.Shared.Contract.Salary.Models;
using CP.Shared.Contract.Salary.Services;
using Ninject;

namespace CP.Compensation.Workflow.Services
{
    public class CompensationWorkflowService : ICompensationWorkflowService
    {
        #region Injects

        [Inject]
        ICompensationPromotionModifyingService CompensationPromotionModifyingService { get; set; }

        [Inject]
        ISalaryPromotionModifyingService SalaryPromotionModifyingService { get; set; }

        [Inject]
        IBonusPromotionModifyingService BonusPromotionModifyingService { get; set; }

        [Inject]
        IDbContextScopeFactory DbContextScopeFactory { get; set; }

        [Inject]
        List<ICompensationPromotionWorkflowStep> CompensationPromotionWorkflowSteps { get; set; }

        [Inject]
        List<ICompensationPromotionWorkflowValidator> CompensationPromotionWorkflowValidators { get; set; }

        #endregion

        public void Create(SalaryPromotionModel model)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                SalaryPromotionModel salary = CreateInternal(model);
                SalaryPromotionModifyingService.AddOrUpdate(salary);

                scope.SaveChanges();
            }
        }

        public void Create(BonusPromotionModel model)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                BonusPromotionModel bonus = CreateInternal(model);
                BonusPromotionModifyingService.AddOrUpdate(bonus);

                scope.SaveChanges();
            }
        }

        private T CreateInternal<T>(T model)
            where T: CompensationPromotionModel
        {
            foreach (ICompensationPromotionWorkflowValidator validator in CompensationPromotionWorkflowValidators)
            {
                validator.Validate(model);
            }

            foreach (ICompensationPromotionWorkflowStep step in CompensationPromotionWorkflowSteps)
            {
                step.Update(model);
            }

            CompensationPromotionModifyingService.AddOrUpdate(model);

            return model;
        }

        public void Reject(SalaryPromotionModel model)
        {
            RejectInternal(model);
            SalaryPromotionModifyingService.AddOrUpdate(model);
        }

        public void Reject(BonusPromotionModel model)
        {
            RejectInternal(model);
            BonusPromotionModifyingService.AddOrUpdate(model);
        }

        private void RejectInternal(CompensationPromotionModel model)
        {
            model.PromotionStatus = CompensationPromotionStatus.Rejected;
            model.Comment = CompensationPromotionStatus.Rejected.ToString();
            CompensationPromotionModifyingService.AddOrUpdate(model);
        }
    }
}