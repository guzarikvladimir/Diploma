using System.Collections.Generic;
using CP.ImportExport.Common.Helpers;
using CP.ImportExport.Common.Services;
using CP.ImportExport.Roles.Contract;
using CP.ImportExport.Roles.Models;
using CP.Shared.Contract.Role.Models;

namespace CP.ImportExport.Roles.Services
{
    public class RoleImportExportService :
        ImportExportServiceBase<RoleImportExportModel, RoleModel, RoleView>,
        IRoleImportExportService
    {
        public override string GetTemplateName()
        {
            return "Roles";
        }

        public override IEnumerable<RoleModel> Parse(List<RoleImportExportModel> importModels)
        {
            foreach (RoleImportExportModel model in importModels)
            {
                yield return new RoleModel()
                {
                    Id = ImportExportHelper.ParseId(model.Id),
                    Name = model.Name
                };
            }
        }

        public override IEnumerable<RoleImportExportModel> GetExportModels()
        {
            IEnumerable<RoleView> models = SimpleRetrievingService.Get();
            foreach (RoleView model in models)
            {
                yield return new RoleImportExportModel()
                {
                    Id = model.Id.ToString(),
                    Name = model.Name
                };
            }
        }
    }
}