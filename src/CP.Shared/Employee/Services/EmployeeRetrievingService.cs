using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Core.Services;

namespace CP.Shared.Employee.Services
{
    public class EmployeeRetrievingService :
        SimpleRetrievingService<Repository.Models.Employee, EmployeeView>,
        IEmployeeRetrievingService
    {
    }
}