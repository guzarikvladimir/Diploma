using System.Web.Mvc;
using CP.Core.Contract.Permission.Models;
using CP.ImportExport.Common.Contract;
using CP.ImportExport.Common.Models;
using CP.Shared.Contract.EmployeeRole.Services;
using CP.Shared.Contract.Role.Models;
using Ninject;

namespace CP.ImportExport.Common.Controllers
{
    public class ExportController : Controller
    {
        #region Injects

        [Inject]
        IImportExportService ImportExportService { get; set; }

        [Inject]
        IEmployeeRoleService EmployeeRoleService { get; set; }

        [Inject]
        IImportExportResolverService ExportResolverService { get; set; }

        #endregion

        [Route("")]
        public ActionResult Index()
        {
            ViewBag.ExportOptions = ImportExportService.GetOptions();

            return View();
        }

        [HttpPost]
        [MvcError]
        public FileContentResult Export(ImportExportOption exportOption)
        {
            if (!EmployeeRoleService.IsInRole(RoleView.Administrators))
            {
                throw new AccessDeniedException();
            }

            TemplateModel file = ExportResolverService.ResolveExport(exportOption);

            return File(file.Content, file.ContentType, file.Name);
        }
    }
}