using System;
using System.Collections.Generic;
using CP.Platform.Period.Models;
using CP.Shared.Contract.Compensation.Models;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Employee.Models;

namespace CP.Compensation.Test.Contract.Table.Models
{
    public class CompensationTableViewTestModel
    {
        public EmployeeView Employee { get; set; }

        public Period Period { get; set; }

        public List<CompensationPromotionView> Compensations { get; set; }

        public ValueWithCurrency Total { get; set; }

        public CompensationTableViewTestModel()
        {
            Compensations = new List<CompensationPromotionView>();
        }
    }
}