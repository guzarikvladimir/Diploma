using CP.Shared.Contract.User.Models;
using CP.Shared.Contract.User.Services;
using CP.Shared.Core.Services;
using UserEntity = CP.Repository.Models.User;

namespace CP.Shared.User.Services
{
    public class UserRetrievingService : 
        SimpleRetrievingService<UserEntity, UserView>, 
        IUserRetrievingService
    {
    }
}