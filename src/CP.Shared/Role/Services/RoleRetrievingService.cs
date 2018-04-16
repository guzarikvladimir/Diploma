using CP.Shared.Contract.Role.Models;
using CP.Shared.Contract.Role.Services;
using CP.Shared.Core.Services;

namespace CP.Shared.Role.Services
{
    public class RoleRetrievingService : 
        SimpleRetrievingService<Repository.Models.Role, RoleView>,
        IRoleRetrievingService
    {
    }
}