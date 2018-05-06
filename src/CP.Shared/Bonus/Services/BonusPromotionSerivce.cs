using System;
using System.Collections.Generic;
using System.Linq;
using CP.Repository.Models;
using CP.Shared.Contract.Bonus.Models;
using CP.Shared.Contract.Bonus.Services;
using Ninject;

namespace CP.Shared.Bonus.Services
{
    public class BonusPromotionSerivce : IBonusPromotionSerivce
    {
        [Inject]
        IBonusPromotionRetrievingService BonusPromotionRetrievingService { get; set; }

        public List<BonusPromotionView> Get(Guid employeeId, bool onlyApproved = false)
        {
            IEnumerable<BonusPromotionView> bonuses = BonusPromotionRetrievingService.Get()
                .Where(b => b.Employee.Id == employeeId);
            if (onlyApproved)
            {
                bonuses = bonuses.Where(b => b.PromotionStatus == CompensationPromotionStatus.Approved);
            }

            return bonuses
                .OrderByDescending(b => b.ApplyDate)
                .ThenByDescending(s => s.CreatedDate)
                .ToList();
        }
    }
}