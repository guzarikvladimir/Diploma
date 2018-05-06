using System;
using System.Collections.Generic;
using CP.Shared.Contract.Compensation.Models;
using CP.Shared.Contract.CompensationPromotion.Models;

namespace CP.Shared.Contract.Compensation.Services
{
    public interface ICompensationCalculationService
    {
        ValueWithCurrency Get(List<CompensationPromotionView> compensations, Guid employeeId, Guid? currencyId,
            DateTime? date = null);
    }
}