using System;
using System.Collections.Generic;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Employee.Models;

namespace CP.Shared.Contract.CompensationPromotion.Services
{
    public interface ICompensationPromotionService
    {
        List<CompensationPromotionView> Get(Guid employeeId, bool onlyApproved = false);

        List<CompensationPromotionView> Get(List<EmployeeView> employees, bool onlyApproved = false);
    }
}