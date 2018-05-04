using System;
using CP.Compensation.Contract.Services;
using CP.Platform.Db.Contract;
using CP.Platform.Identity.Contract;
using CP.Platform.Identity.Helpers;
using CP.Repository.Models;
using CP.Shared.Contract.Bonus.Models;
using CP.Shared.Contract.Bonus.Services;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.CompensationPromotion.Services;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Contract.Salary.Models;
using CP.Shared.Contract.Salary.Services;
using Ninject;

namespace CP.Compensation.Workflow.Services
{
    public class CompensationWorkflowService : ICompensationWorkflowService
    {
        #region Injects

        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        [Inject]
        IUserService UserService { get; set; }

        [Inject]
        ICompensationPromotionModifyingService CompensationPromotionModifyingService { get; set; }

        [Inject]
        ISalaryPromotionModifyingService SalaryPromotionModifyingService { get; set; }

        [Inject]
        IBonusPromotionModifyingService BonusPromotionModifyingService { get; set; }

        [Inject]
        IDbFactory DbFactory { get; set; }

        #endregion
        
        public void Create(SalaryPromotionModel model)
        {
            using (var scope = DbFactory.Create())
            {
                SalaryPromotionModel salary = CreateInternal(model);
                SalaryPromotionModifyingService.Add(salary);

                scope.SaveChanges();
            }
        }

        public void Create(BonusPromotionModel model)
        {
            using (var scope = DbFactory.Create())
            {
                BonusPromotionModel bonus = CreateInternal(model);
                BonusPromotionModifyingService.Add(bonus);

                scope.SaveChanges();
            }
        }

        private T CreateInternal<T>(T model)
            where T: CompensationPromotionModel
        {
            model.Id = Guid.NewGuid();
            model.CreatedDate = DateTime.Now;
            model.CreatedById = UserService.Current.GetUserId();
            model.PromotionStatus = CompensationPromotionStatus.Approved;

            CompensationPromotionModifyingService.Add(model);

            return model;
        }
    }
}