using System.Web.Configuration;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using WebApi;

[assembly: OwinStartup(typeof(Startup))]
namespace WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = WebConfigurationManager.AppSettings["AuthenticationType"],
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}