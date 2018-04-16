using CP.Shared.Contract.User.Models;
using CP.Shared.Contract.User.Services;
using CP.Shared.Core.Services;

namespace CP.Shared.User.Services
{
    public class UserRetrievingService : 
        SimpleRetrievingService<Repository.Models.User, UserView>, 
        IUserRetrievingService
    {
    }
}