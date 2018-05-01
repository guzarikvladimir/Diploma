using System;
using System.Collections.Generic;
using System.Linq;
using CP.Compensation.Contract.Models;
using CP.Compensation.Contract.Services;
using CP.Shared.Contract.Bonus.Models;
using CP.Shared.Contract.Bonus.Services;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.CompensationPromotion.Services;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Contract.Salary.Models;
using CP.Shared.Contract.Salary.Services;
using Ninject;

namespace CP.Compensation.Services
{
    public class CompensationSerivce : ICompensationSerivce
    {
        #region Injects

        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        [Inject]
        ICompensationPromotionService CompensationPromotionService { get; set; }

        #endregion

        public IEnumerable<CompensationView> Get()
        {
            IEnumerable<EmployeeView> employees = EmployeeRetrievingService.Get();
            foreach (EmployeeView employee in employees)
            {
                List<CompensationPromotionView> compensations = CompensationPromotionService.Get(employee.Id);

                yield return new CompensationView()
                {
                    Employee = employee,
                    CompensationPromotions = compensations
                };
            }
        }

        public CompensationView Get(Guid employeeId)
        {
            EmployeeView employee = EmployeeRetrievingService.GetById(employeeId);
            List<CompensationPromotionView> compensations = CompensationPromotionService.Get(employeeId);

            return new CompensationView()
            {
                Employee = employee,
                CompensationPromotions = compensations
            };
        }
    }
}