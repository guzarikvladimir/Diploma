using System.Collections.Generic;
using System.Linq;
using CP.Compensation.Table.Contract;
using CP.Compensation.Table.Models;
using CP.Platform.Helpers;
using CP.Shared.Contract.Compensation.Models;
using CP.Shared.Contract.Compensation.Services;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.CompensationPromotion.Services;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Employee.Services;
using Ninject;

namespace CP.Compensation.Table.Services
{
    public class CompensationTableSerivce : ICompensationTableSerivce
    {
        #region Injects

        [Inject]
        IEmployeeSerice EmployeeService { get; set; }

        [Inject]
        ICompensationPromotionService CompensationPromotionService { get; set; }

        [Inject]
        ICompensationCalculationService CompensationCalculationService { get; set; }

        #endregion

        public CompensationTableView Get(CompensationTableParameters parameters)
        {
            List<EmployeeView> employees = EmployeeService.Get(parameters);
            var view = new CompensationTableView();
            foreach (EmployeeView employee in employees)
            {
                view.CompensationsByEmployees.Add(GetByEmployee(employee));
            }

            List<CompensationPromotionView> allCompensations = CompensationPromotionService
                .Get(employees, onlyApproved: true);
            view.Total = CompensationCalculationService.Get(allCompensations);

            return view;
        }

        private CompensationsByEmployee GetByEmployee(EmployeeView employee)
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

            return new CompensationsByEmployee()
            {
                Employee = employee,
                CompensationsByPeriods = compensationsByPeriods,
                Total = CompensationCalculationService.Get(compensations)
            };
        }
    }
}