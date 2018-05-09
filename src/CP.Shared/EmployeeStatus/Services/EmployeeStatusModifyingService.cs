using CP.Shared.Contract.EmployeeStatus.Models;
using CP.Shared.Contract.EmployeeStatus.Services;
using CP.Shared.Core.Services;
using EmployeeStatusEntity = CP.Repository.Models.EmployeeStatus;

namespace CP.Shared.EmployeeStatus.Services
{
    public class EmployeeStatusModifyingService :
        SimpleModifyingService<EmployeeStatusEntity, EmployeeStatusModel>,
        IEmployeeStatusModifyingService
    {
    }
}