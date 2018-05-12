using CP.Platform.Crud.Services;
using CP.Shared.Contract.EmployeeRole.Models;
using CP.Shared.Contract.EmployeeRole.Services;
using EmployeeRoleEntity = CP.Repository.Models.EmployeeRole;

namespace CP.Shared.EmployeeRole.Services
{
    public class EmployeeRoleRetrievingService : 
        SimpleRetrievingService<EmployeeRoleEntity, EmployeeRoleView>,
        IEmployeeRoleRetrievingService
    {
    }
}