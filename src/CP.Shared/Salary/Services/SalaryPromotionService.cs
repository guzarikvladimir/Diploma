using System;
using System.Collections.Generic;
using System.Linq;
using CP.Repository.Models;
using CP.Shared.Contract.Salary.Models;
using CP.Shared.Contract.Salary.Services;
using Ninject;

namespace CP.Shared.Salary.Services
{
    public class SalaryPromotionService : ISalaryPromotionService
    {
        [Inject]
        ISalaryPromotionRetrievingService SalaryPromotionRetrievingService { get; set; }

        public List<SalaryPromotionView> Get(Guid employeeId, bool onlyApproved = false)
        {
            IEnumerable<SalaryPromotionView> salaries = SalaryPromotionRetrievingService.Get()
                .Where(s => s.Employee.Id == employeeId);
            if (onlyApproved)
            {
                salaries = salaries.Where(s => s.PromotionStatus == CompensationPromotionStatus.Approved);
            }

            return salaries
                .OrderByDescending(c => c.ApplyDate)
                .ThenByDescending(c => c.CreatedDate)
                .ToList();
        }
    }
}