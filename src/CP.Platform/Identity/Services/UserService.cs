using System.Security.Principal;
using System.Web;
using CP.Platform.Identity.Contract;

namespace CP.Platform.Identity.Services
{
    public class UserService : IUserService
    {
        public IIdentity Current => HttpContext.Current.User.Identity;
    }
}