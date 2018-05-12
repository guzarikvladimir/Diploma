using System;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using CP.Authorization.Contract.Models;
using CP.Authorization.Contract.Services;
using Microsoft.Owin.Security;
using Ninject;
using LoginView = CP.Authorization.Contract.Models.LoginView;

namespace CP.Authorization.Controllers
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
                    
                    return RedirectToAction("Index", "Compensation");
                }
                catch (Exception e)
                {
                    //ParamName
                    ModelState.AddModelError("", e.Message);
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterView model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserService.Register(model);

                    return Login(new LoginView()
                    {
                        Email = model.Email,
                        Password = model.Password
                    });
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

            return RedirectToAction("Login");
        }
    }
}