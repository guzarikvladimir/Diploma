using System.Collections.Generic;
using CP.Shared.Contract.Compensation.Models;
using CP.Shared.Contract.Employee.Models;

namespace CP.Compensation.Contract.Models
{
    public class CompensationTableView
    {
        public EmployeeView Employee { get; set; }

        public IEnumerable<CompensationsByPeriodView> CompensationsByPeriods { get; set; }

        public ValueWithCurrency Total { get; set; }
    }
}