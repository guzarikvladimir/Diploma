using System.Collections.Generic;
using CP.Shared.Contract.Compensation.Models;

namespace CP.Compensation.Table.Models
{
    public class CompensationTableView
    {
        public List<CompensationsByEmployee> CompensationsByEmployees { get; set; }

        public ValueWithCurrency Total { get; set; }

        public CompensationTableView()
        {
            CompensationsByEmployees = new List<CompensationsByEmployee>();
        }
    }
}