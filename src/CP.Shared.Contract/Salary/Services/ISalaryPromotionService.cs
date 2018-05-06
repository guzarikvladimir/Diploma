using System;
using System.Collections.Generic;
using CP.Shared.Contract.Salary.Models;

namespace CP.Shared.Contract.Salary.Services
{
    public interface ISalaryPromotionService
    {
        List<SalaryPromotionView> Get(Guid employeeId, bool onlyApproved = false);
    }
}