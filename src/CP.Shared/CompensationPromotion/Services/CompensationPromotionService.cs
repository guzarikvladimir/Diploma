using System;
using System.Collections.Generic;
using System.Linq;
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
        ISalaryPromotionRetrievingService SalaryPromotionRetrievingService { get; set; }

        [Inject]
        IBonusPromotionRetrievingService BonusPromotionRetrievingService { get; set; }

        #endregion

        public List<CompensationPromotionView> Get(Guid employeeId)
        {
            IEnumerable<CompensationPromotionView> salaries = SalaryPromotionRetrievingService.Get()
                .Where(s => s.Employee.Id == employeeId);
            IEnumerable<CompensationPromotionView> bonuses = BonusPromotionRetrievingService.Get()
                .Where(b => b.Employee.Id == employeeId);
            List<CompensationPromotionView> compensations = salaries.ToList();
            compensations.AddRange(bonuses);

            return compensations
                .OrderByDescending(c => c.ApplyDate)
                .ThenBy(c => c.CreatedDate)
                .ToList();
        }
    }
}