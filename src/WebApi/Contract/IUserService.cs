using System.Security.Claims;
using WebApi.Models;

namespace WebApi.Contract
{
    public interface IUserService
    {
        ClaimsIdentity Login(LoginView model);
    }
}