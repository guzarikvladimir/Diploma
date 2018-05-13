using System.Collections.Generic;
using System.Linq;
using CP.ImportExport.Common.Helpers;
using CP.ImportExport.Common.Services;
using CP.ImportExport.EmployeeRole.Contract;
using CP.ImportExport.EmployeeRole.Models;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Contract.EmployeeRole.Models;
using CP.Shared.Contract.Role.Services;
using Ninject;

namespace CP.ImportExport.EmployeeRole.Services
{
    public class EmployeeRoleImportExportService :
        ImportExportServiceBase<EmployeeRoleImportExportModel, EmployeeRoleModel, EmployeeRoleView>,
        IEmployeeRoleImportExportService
    {
        #region Injects

        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        [Inject]
        IRoleRetrievingService RoleRetrievingService { get; set; }

        #endregion

        public override string GetTemplateName()
        {
            return "EmployeeRoles";
        }

        public override IEnumerable<EmployeeRoleModel> Parse(List<EmployeeRoleImportExportModel> importModels)
        {
            foreach (EmployeeRoleImportExportModel model in importModels)
            {
                yield return new EmployeeRoleModel()
                {
                    Id = ImportExportHelper.ParseId(model.Id),
                    EmployeeId = EmployeeRetrievingService.Get().First(e => e.Email == model.Employee).Id,
                    RoleId = RoleRetrievingService.Get().First(r => r.Name == model.Role).Id
                };
            }
        }

        public override IEnumerable<EmployeeRoleImportExportModel> GetExportModels()
        {
            IEnumerable<EmployeeRoleView> models = SimpleRetrievingService.Get();
            foreach (EmployeeRoleView model in models)
            {
                yield return new EmployeeRoleImportExportModel()
                {
                    Id = model.Id.ToString(),
                    Employee = model.Employee.Email,
                    Role = model.Role.Name
                };
            }
        }
    }
}