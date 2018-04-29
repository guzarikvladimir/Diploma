using System;
using System.Collections.Generic;
using System.Linq;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.CompensationPromotion.Services;
using CP.Shared.Core.Services;
using CompensationPromotionEntity = CP.Repository.Models.CompensationPromotion;

namespace CP.Shared.CompensationPromotion.Services
{
    public class CompensationPromotionRetrievingService :
        SimpleRetrievingService<CompensationPromotionEntity, CompensationPromotionView>,
        ICompensationPromotionRetrievingService
    {
        public IEnumerable<CompensationPromotionView> GetByEmployee(Guid employeeId)
        {
            return Get().Where(cp => cp.Employee.Id == employeeId);
        }
    }
}