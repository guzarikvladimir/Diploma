using System.Web.Mvc;

namespace CP.Compensation.Controllers
{
    [Authorize]
    public class CompensationController : Controller
    {
        public ActionResult Get()
        {
            return View();
        }
    }
}