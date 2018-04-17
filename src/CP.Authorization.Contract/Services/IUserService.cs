using System.Security.Claims;
using CP.Authorization.Contract.Models;

namespace CP.Authorization.Contract.Services
{
    public interface IUserService
    {
        ClaimsIdentity Login(LoginView model);

        void Register(RegisterView view);
    }
}