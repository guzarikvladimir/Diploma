using CP.Platform.Crud.Services;
using CP.Shared.Contract.Role.Models;
using CP.Shared.Contract.Role.Services;

namespace CP.Shared.Role.Services
{
    public class RoleRetrievingService : 
        SimpleRetrievingService<Repository.Models.Role, RoleView>,
        IRoleRetrievingService
    {
    }
}