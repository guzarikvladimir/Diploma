using CP.Platform.Crud.Services;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Employee.Services;
using EmployeeEntity = CP.Repository.Models.Employee;

namespace CP.Shared.Employee.Services
{
    public class EmployeeRetrievingService :
        SimpleRetrievingService<EmployeeEntity, EmployeeView>,
        IEmployeeRetrievingService
    {
    }
}