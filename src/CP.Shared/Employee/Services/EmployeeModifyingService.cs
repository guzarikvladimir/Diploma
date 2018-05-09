using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Core.Services;
using EmployeeEntity = CP.Repository.Models.Employee;

namespace CP.Shared.Employee.Services
{
    public class EmployeeModifyingService :
        SimpleModifyingService<EmployeeEntity, EmployeeModel>,
        IEmployeeModifyingService
    {
    }
}