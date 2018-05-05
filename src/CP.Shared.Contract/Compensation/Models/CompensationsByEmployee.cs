using System.Collections.Generic;
using CP.Shared.Contract.Employee.Models;

namespace CP.Shared.Contract.Compensation.Models
{
    public class CompensationsByEmployee
    {
        public EmployeeView Employee { get; set; }

        public List<CompensationsByPeriodView> CompensationsByPeriods { get; set; }

        public ValueWithCurrency Total { get; set; }

        public CompensationsByEmployee()
        {
            CompensationsByPeriods = new List<CompensationsByPeriodView>();
        }
    }
}