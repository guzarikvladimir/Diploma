using CP.Platform.Crud.Services;
using CP.Shared.Contract.Role.Models;
using CP.Shared.Contract.Role.Services;
using RoleEntity = CP.Repository.Models.Role;

namespace CP.Shared.Role.Services
{
    public class RoleModifyingService :
        SimpleModifyingService<RoleEntity, RoleModel, RoleView>,
        IRoleModifyingService
    {
    }
}