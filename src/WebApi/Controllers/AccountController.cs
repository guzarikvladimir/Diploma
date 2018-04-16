using System;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Ninject;
using WebApi.Contract;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class AccountController : Controller
    {
        [Inject]
        IUserService UserService { get; set; }

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginView model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ClaimsIdentity claim = UserService.Login(model);

                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties()
                    {
                        IsPersistent = true
                    }, claim);

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}