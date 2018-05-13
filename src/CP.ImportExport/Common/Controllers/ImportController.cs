using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CP.Core.Contract.Permission.Models;
using CP.ImportExport.Common.Contract;
using CP.ImportExport.Common.Models;
using CP.Shared.Contract.EmployeeRole.Services;
using CP.Shared.Contract.Role.Models;
using Ninject;

namespace CP.ImportExport.Common.Controllers
{
    [System.Web.Mvc.RoutePrefix("Import")]
    public class ImportController : Controller
    {
        #region Injects

        [Inject]
        IImportExportResolverService ImportExportResolverService { get; set; }

        [Inject]
        IEmployeeRoleService EmployeeRoleService { get; set; }

        [Inject]
        IImportExportService ImportExportService { get; set; }

        #endregion

        [System.Web.Mvc.Route("")]
        public ActionResult Index()
        {
            ViewBag.ImportOptions = ImportExportService.GetOptions();

            return View();
        }

        [System.Web.Mvc.HttpPost]
        [MvcError]
        public void Upload([FromUri] ImportExportOption importOption)
        {
            if (!EmployeeRoleService.IsInRole(RoleView.Administrators))
            {
                throw new AccessDeniedException();
            }

            HttpPostedFileBase file = Request.Files[0];
            if (file != null && file.ContentLength > 0 && !string.IsNullOrEmpty(file.FileName))
            {
                ImportExportResolverService.ResolveImport(importOption, file);
            }
        }

        [System.Web.Mvc.HttpPost]
        [MvcError]
        public FileContentResult Template(ImportExportOption importOption)
        {
            if (!EmployeeRoleService.IsInRole(RoleView.Administrators))
            {
                throw new AccessDeniedException();
            }

            TemplateModel template = ImportExportResolverService.GenerateTemplate(importOption);

            return File(template.Content, template.ContentType, template.Name);
        }
    }
}