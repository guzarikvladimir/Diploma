using CP.Shared.Contract.EmployeeToLegalEntity.Models;
using CP.Shared.Contract.EmployeeToLegalEntity.Services;
using CP.Shared.Core.Services;
using EmployeeToLegalEntityEntity = CP.Repository.Models.EmployeeToLegalEntity;

namespace CP.Shared.EmployeeToLegalEntity.Services
{
    public class EmployeeToLegalEntityModifyingService : 
        SimpleModifyingService<EmployeeToLegalEntityEntity, EmployeeToLegalEntityModel>,
        IEmployeeToLegalEntityModifyingService
    {
    }
}