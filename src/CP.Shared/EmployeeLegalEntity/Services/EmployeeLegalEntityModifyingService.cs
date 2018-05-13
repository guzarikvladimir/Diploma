using CP.Platform.Crud.Services;
using CP.Shared.Contract.EmployeeLegalEntity.Models;
using CP.Shared.Contract.EmployeeLegalEntity.Services;
using EmployeeLegalEntityEntity = CP.Repository.Models.EmployeeLegalEntity;

namespace CP.Shared.EmployeeLegalEntity.Services
{
    public class EmployeeLegalEntityModifyingService : 
        SimpleModifyingService<EmployeeLegalEntityEntity, EmployeeLegalEntityModel, EmployeeLegalEntityView>,
        IEmployeeLegalEntityModifyingService
    {
    }
}