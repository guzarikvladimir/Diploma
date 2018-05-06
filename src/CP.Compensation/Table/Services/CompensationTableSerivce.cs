using System;
using System.Collections.Generic;
using System.Linq;
using CP.Compensation.Table.Contract;
using CP.Compensation.Table.Models;
using CP.Platform.Helpers;
using CP.Shared.Contract.Compensation.Models;
using CP.Shared.Contract.Compensation.Services;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.CompensationPromotion.Services;
using CP.Shared.Contract.Currency.Services;
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

        [Inject]
        ICurrencyConverterService CurrencyConverterService { get; set; }

        #endregion

        public CompensationTableView Get(CompensationTableParameters parameters)
        {
            List<EmployeeView> employees = EmployeeService.Get(parameters);
            var view = new CompensationTableView();
            foreach (EmployeeView employee in employees)
            {
                view.CompensationsByEmployees.Add(GetByEmployee(employee, parameters));
            }

            return view;
        }

        private CompensationsByEmployee GetByEmployee(EmployeeView employee, CompensationTableParameters parameters)
        {
            List<CompensationPromotionView> compensations = CompensationPromotionService
                .Get(employee.Id, onlyApproved: true);
            List<CompensationsByPeriodView> compensationsByPeriods = compensations
                .GroupBy(cp => cp.ApplyDate.ToLowerDate())
                .Select(compensationsByPeriod => new CompensationsByPeriodView()
                {
                    Period = compensationsByPeriod.Key,
                    CompensationPromotions = compensationsByPeriod,
                    Total = CompensationCalculationService
                        .Get(compensationsByPeriod.ToList(), employee.Id, parameters.CurrencyId)
                })
                .ToList();

            return new CompensationsByEmployee()
            {
                Employee = employee,
                CompensationsByPeriods = compensationsByPeriods,
                Total = GetEmployeeTotal(compensationsByPeriods, parameters.CurrencyId)
            };
        }

        private ValueWithCurrency GetEmployeeTotal(List<CompensationsByPeriodView> compensationsByPeriods, Guid? currencyId)
        {
            ValueWithCurrency result = null;
            foreach (CompensationsByPeriodView compensationsByPeriod in compensationsByPeriods)
            {
                result = CurrencyConverterService.Add(result, compensationsByPeriod.Total, currencyId);
            }

            return result;
        }
    }
}