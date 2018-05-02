using System.Web.Mvc;

namespace CP.Compensation.Table.Controllers
{
    [Authorize]
    public class CompensationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}