using System;
using CP.Compensation.Contract.Services;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Employee.Services;
using Ninject;
using CP.Platform.Identity.Contract;
using CP.Platform.Identity.Helpers;
using CP.Repository.Models;
using CP.Shared.Contract.CompensationPromotion.Services;

namespace CP.Compensation.Services
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

        #endregion
        
        public void Create(CompensationPromotionModel model)
        {
            Guid userId = UserService.Current.GetUserId();
            model.Id = Guid.NewGuid();
            model.CreatedDate = DateTime.Now;
            model.CreatedBy = EmployeeRetrievingService.GetById(userId);

            CompensationPromotionModifyingService.Add(model);

            if (model.PromotionType == CompensationPromotionType.Salary)
            {

            }
        }
    }
}