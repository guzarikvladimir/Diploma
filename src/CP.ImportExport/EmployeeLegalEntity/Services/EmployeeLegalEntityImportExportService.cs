using System.Collections.Generic;
using System.Linq;
using CP.ImportExport.Common.Helpers;
using CP.ImportExport.Common.Services;
using CP.ImportExport.EmployeeLegalEntity.Contract;
using CP.ImportExport.EmployeeLegalEntity.Models;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Contract.EmployeeLegalEntity.Models;
using CP.Shared.Contract.LegalEntity.Services;
using Ninject;

namespace CP.ImportExport.EmployeeLegalEntity.Services
{
    public class EmployeeLegalEntityImportExportService :
        ImportExportServiceBase<EmployeeLegalEntityImportExportModel, EmployeeLegalEntityModel, EmployeeLegalEntityView>,
        IEmployeeLegalEntityImportExportService
    {
        #region Injects

        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        [Inject]
        ILegalEntityRetrievingService LegalEntityRetrievingService { get; set; }

        #endregion

        public override string GetTemplateName()
        {
            return "EmployeeLegalEntities";
        }

        public override IEnumerable<EmployeeLegalEntityModel> Parse(List<EmployeeLegalEntityImportExportModel> importModels)
        {
            foreach (EmployeeLegalEntityImportExportModel model in importModels)
            {
                yield return new EmployeeLegalEntityModel()
                {
                    Id = ImportExportHelper.ParseId(model.Id),
                    EmployeeId = EmployeeRetrievingService.Get().First(e => e.Email == model.Employee).Id,
                    LegalEntityId = LegalEntityRetrievingService.Get().First(le => le.Name == model.LegalEntity).Id,
                    IsPrimary = bool.Parse(model.IsPrimary)
                };
            }
        }

        public override IEnumerable<EmployeeLegalEntityImportExportModel> GetExportModels()
        {
            IEnumerable<EmployeeLegalEntityView> models = SimpleRetrievingService.Get();
            foreach (EmployeeLegalEntityView model in models)
            {
                yield return new EmployeeLegalEntityImportExportModel()
                {
                    Id = model.Id.ToString(),
                    Employee = model.Employee.Email,
                    LegalEntity = model.LegalEntity.Name,
                    IsPrimary = model.IsPrimary.ToString()
                };
            }
        }
    }
}