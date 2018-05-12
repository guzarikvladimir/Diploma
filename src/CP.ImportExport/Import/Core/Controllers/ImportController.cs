using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CP.ImportExport.Import.Core.Contract;
using CP.ImportExport.Import.Core.Models;
using CP.Platform.Helpers;
using Ninject;

namespace CP.ImportExport.Import.Core.Controllers
{
    [RoutePrefix("Import")]
    public class ImportController : Controller
    {
        [Inject]
        IImportResolverService ImportResolverService { get; set; }

        [Route("")]
        public ActionResult Index()
        {
            var enumData = from ImportOption e in Enum.GetValues(typeof(ImportOption))
                           select new
                           {
                               Id = (int)e,
                               Name = e.GetDisplayValue()
                           };
            ViewBag.ImportOptions = new SelectList(enumData, "Id", "Name");

            return View();
        }
        
        [HttpPost]
        public void Upload(ImportOption importOption)
        {
            HttpPostedFileBase file = Request.Files[0];
            if (file != null && file.ContentLength > 0 && !string.IsNullOrEmpty(file.FileName))
            {
                ImportResolverService.Resolve(importOption, file);
            }
        }

        [HttpGet]
        public FileContentResult Template(ImportOption importOption)
        {
            TemplateModel template = ImportResolverService.GenerateTemplate(importOption);

            return File(template.Content, template.ContentType, template.Name);
        }
    }
}