using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CP.Core.Contract.Permission.Models;
using CP.ImportExport.Import.Core.Contract;
using CP.ImportExport.Import.Core.Models;
using CP.Platform.Helpers;
using CP.Shared.Contract.Role.Models;
using Ninject;
using CP.Shared.EmployeeRole.Services;

namespace CP.ImportExport.Import.Core.Controllers
{
    [RoutePrefix("Import")]
    public class ImportController : Controller
    {
        #region Injects

        [Inject]
        IImportResolverService ImportResolverService { get; set; }

        [Inject]
        EmployeeRoleService EmployeeRoleService { get; set; }

        #endregion

        [Route("")]
        public ActionResult Index()
        {
            ViewBag.ImportOptions = GetOptions();

            return View();
        }
        
        [HttpPost]
        [MvcError]
        public void Upload(ImportOption importOption)
        {
            if (!EmployeeRoleService.IsInRole(RoleView.Administrators))
            {
                throw new AccessDeniedException();
            }

            HttpPostedFileBase file = Request.Files[0];
            if (file != null && file.ContentLength > 0 && !string.IsNullOrEmpty(file.FileName))
            {
                ImportResolverService.Resolve(importOption, file);
            }
        }

        [HttpPost]
        [MvcError]
        public FileContentResult Template(ImportOption importOption)
        {
            if (!EmployeeRoleService.IsInRole(RoleView.Administrators))
            {
                throw new AccessDeniedException();
            }

            TemplateModel template = ImportResolverService.GenerateTemplate(importOption);

            return File(template.Content, template.ContentType, template.Name);
        }

        private SelectList GetOptions()
        {
            var enumData = from ImportOption e in Enum.GetValues(typeof(ImportOption))
                select new
                {
                    Id = (int)e,
                    Name = e.GetDisplayValue()
                };

            return new SelectList(enumData, "Id", "Name");
        }
    }
}