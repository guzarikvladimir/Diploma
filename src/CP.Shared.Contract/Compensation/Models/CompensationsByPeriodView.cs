using System;
using System.Collections.Generic;
using CP.Shared.Contract.CompensationPromotion.Models;

namespace CP.Shared.Contract.Compensation.Models
{
    public class CompensationsByPeriodView
    {
        public DateTime Period { get; set; }

        public IEnumerable<CompensationPromotionView> CompensationPromotions { get; set; }

        public ValueWithCurrency Total { get; set; }
    }
}