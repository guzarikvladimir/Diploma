using CP.Platform.Crud.Services;
using CP.Shared.Contract.EmployeeStatus.Models;
using CP.Shared.Contract.EmployeeStatus.Services;
using EmployeeStatusEntity = CP.Repository.Models.EmployeeStatus;

namespace CP.Shared.EmployeeStatus.Services
{
    public class EmployeeStatusRetrievingService :
        SimpleRetrievingService<EmployeeStatusEntity, EmployeeStatusView>,
        IEmployeeStatusRetrievingService
    {
    }
}