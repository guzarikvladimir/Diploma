using System.Security.Principal;

namespace CP.Platform.Identity.Contract
{
    public interface IUserService
    {
        IIdentity Current { get; }
    }
}