using System;
using System.Collections.Generic;
using System.Linq;
using CP.Shared.Contract.Bonus.Models;
using CP.Shared.Contract.Bonus.Services;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.CompensationPromotion.Services;
using CP.Shared.Contract.Salary.Models;
using CP.Shared.Contract.Salary.Services;
using Ninject;

namespace CP.Shared.CompensationPromotion.Services
{
    public class CompensationPromotionService : ICompensationPromotionService
    {
        #region Injects

        [Inject]
        ISalaryPromotionService SalaryPromotionService { get; set; }

        [Inject]
        IBonusPromotionSerivce BonusPromotionService { get; set; }

        #endregion

        public List<CompensationPromotionView> Get(Guid employeeId, bool onlyApproved = false)
        {
            List<SalaryPromotionView> salaries = SalaryPromotionService.Get(employeeId, onlyApproved);
            List<BonusPromotionView> bonuses = BonusPromotionService.Get(employeeId, onlyApproved);
            List<CompensationPromotionView> compensations = salaries.Cast<CompensationPromotionView>().ToList();
            compensations.AddRange(bonuses);

            return compensations
                .OrderByDescending(c => c.ApplyDate)
                .ThenByDescending(c => c.CreatedDate)
                .ToList();
        }
    }
}