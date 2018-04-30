using System;
using System.Collections.Generic;
using System.Linq;
using CP.Compensation.Contract.Models;
using CP.Compensation.Contract.Services;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.CompensationPromotion.Services;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Employee.Services;
using Ninject;

namespace CP.Compensation.Services
{
    public class CompensationSerivce : ICompensationSerivce
    {
        #region Injects

        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        [Inject]
        ICompensationPromotionRetrievingService CompensationPromotionRetrievingService { get; set; }

        #endregion

        public IEnumerable<CompensationView> Get()
        {
            IEnumerable<EmployeeView> employees = EmployeeRetrievingService.Get();
            foreach (EmployeeView employee in employees)
            {
                IEnumerable<CompensationPromotionView> compensations = CompensationPromotionRetrievingService.Get()
                    .Where(cp => cp.Employee.Id == employee.Id);
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

            return new CompensationView()
            {
                Employee = employee
            };
        }
    }
}