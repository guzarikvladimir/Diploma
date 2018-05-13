using System.Collections.Generic;
using CP.ImportExport.Common.Helpers;
using CP.ImportExport.Common.Services;
using CP.ImportExport.EmployeeStatus.Contract;
using CP.ImportExport.EmployeeStatus.Models;
using CP.Shared.Contract.EmployeeStatus.Models;

namespace CP.ImportExport.EmployeeStatus.Services
{
    public class EmployeeStatusImportExportService :
        ImportExportServiceBase<EmployeeStatusImportExportModel, EmployeeStatusModel, EmployeeStatusView>,
        IEmployeeStatusImportExportService
    {
        public override string GetTemplateName()
        {
            return "EmployeeStatuses";
        }

        public override IEnumerable<EmployeeStatusModel> Parse(List<EmployeeStatusImportExportModel> importModels)
        {
            foreach (EmployeeStatusImportExportModel model in importModels)
            {
                yield return new EmployeeStatusModel()
                {
                    Id = ImportExportHelper.ParseId(model.Id),
                    Name = model.Name
                };
            }
        }

        public override IEnumerable<EmployeeStatusImportExportModel> GetExportModels()
        {
            IEnumerable<EmployeeStatusView> models = SimpleRetrievingService.Get();
            foreach (EmployeeStatusView model in models)
            {
                yield return new EmployeeStatusImportExportModel()
                {
                    Id = model.Id.ToString(),
                    Name = model.Name
                };
            }
        }
    }
}