using System.Collections.Generic;
using System.Linq;
using CP.Compensation.Contract.Models;
using CP.Compensation.Contract.Services;
using CP.Platform.Helpers;
using CP.Shared.Contract.Compensation.Models;
using CP.Shared.Contract.Compensation.Services;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.CompensationPromotion.Services;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Employee.Services;
using Ninject;

namespace CP.Compensation.Services
{
    public class CompensationTableSerivce : ICompensationTableSerivce
    {
        #region Injects

        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        [Inject]
        ICompensationPromotionService CompensationPromotionService { get; set; }

        [Inject]
        ICompensationCalculationService CompensationCalculationService { get; set; }

        #endregion

        public IEnumerable<CompensationTableView> Get()
        {
            IEnumerable<EmployeeView> employees = EmployeeRetrievingService.Get();
            foreach (EmployeeView employee in employees)
            {
                List<CompensationPromotionView> compensations = CompensationPromotionService
                    .Get(employee.Id, onlyApproved: true);
                List<CompensationsByPeriodView> compensationsByPeriods = compensations
                    .GroupBy(cp => cp.ApplyDate.ToLowerDate())
                    .Select(compensationsByPeriod => new CompensationsByPeriodView()
                    {
                        Period = compensationsByPeriod.Key,
                        CompensationPromotions = compensationsByPeriod,
                        Total = CompensationCalculationService.Get(compensationsByPeriod.ToList())
                    })
                    .ToList();

                yield return new CompensationTableView()
                {
                    Employee = employee,
                    CompensationsByPeriods = compensationsByPeriods,
                    Total = CompensationCalculationService.Get(compensations)
                };
            }
        }
    }
}