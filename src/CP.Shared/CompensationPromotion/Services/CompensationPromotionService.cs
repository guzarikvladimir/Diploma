using System;
using System.Collections.Generic;
using CP.Repository.Models;
using CP.Shared.Contract.Bonus.Services;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.CompensationPromotion.Services;
using CP.Shared.Contract.Salary.Services;
using Ninject;

namespace CP.Shared.CompensationPromotion.Services
{
    public class CompensationPromotionService : ICompensationPromotionService
    {
        #region Injects

        [Inject]
        ICompensationPromotionRetrievingService CompensationPromotionRetrievingService { get; set; }

        [Inject]
        ISalaryPromotionRetrievingService SalaryPromotionRetrievingService { get; set; }

        [Inject]
        IBonusPromotionRetrievingService BonusPromotionRetrievingService { get; set; }

        #endregion

        //public IEnumerable<CompensationPromotionView> Get(Guid employeeId)
        //{
        //    IEnumerable<CompensationPromotionView> compensations = 
        //        CompensationPromotionRetrievingService.Get(employeeId);
        //    foreach (CompensationPromotionView compensation in compensations)
        //    {
        //        if (compensation.PromotionType == CompensationPromotionType.Salary)
        //        {

        //        }
        //    }
        //}
    }
}