using System.Web;
using System.Web.Mvc;
using CP.ImportExport.Import.Core.Contract;
using CP.ImportExport.Import.Core.Models;
using Ninject;

namespace CP.ImportExport.Import.Core.Controllers
{
    [RoutePrefix("Import")]
    public class ImportController : Controller
    {
        [Inject]
        IImportResolverService ImportResolverService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [Route("Upload")]
        [HttpPost]
        public void Upload(ImportOption importOption)
        {
            HttpPostedFileBase file = Request.Files[0];
            if (file != null && file.ContentLength > 0 && !string.IsNullOrEmpty(file.FileName))
            {
                ImportResolverService.Resolve(importOption, file);
            }
        }
    }
}