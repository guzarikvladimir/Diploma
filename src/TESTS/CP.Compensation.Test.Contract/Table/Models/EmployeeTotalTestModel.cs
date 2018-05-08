using CP.Shared.Contract.Compensation.Models;
using CP.Shared.Contract.Employee.Models;

namespace CP.Compensation.Test.Contract.Table.Models
{
    public class EmployeeTotalTestModel
    {
        public EmployeeView Employee { get; set; }

        public ValueWithCurrency Total { get; set; }
    }
}