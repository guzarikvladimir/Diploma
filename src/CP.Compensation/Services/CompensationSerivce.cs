using System.Collections.Generic;
using CP.Compensation.Contract.Models;
using CP.Compensation.Contract.Services;
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
                yield return new CompensationView()
                {
                    Employee = employee,
                    CompensationPromotions = CompensationPromotionRetrievingService.GetByEmployee(employee.Id)
                };
            }
        }
    }
}