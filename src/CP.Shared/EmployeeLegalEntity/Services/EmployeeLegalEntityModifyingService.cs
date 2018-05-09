using CP.Shared.Contract.EmployeeLegalEntity.Models;
using CP.Shared.Contract.EmployeeLegalEntity.Services;
using CP.Shared.Core.Services;

namespace CP.Shared.EmployeeLegalEntity.Services
{
    public class EmployeeLegalEntityModifyingService : 
        SimpleModifyingService<Repository.Models.EmployeeLegalEntity, EmployeeLegalEntityModel>,
        IEmployeeLegalEntityModifyingService
    {
    }
}