using System.Collections.Generic;
using System.Linq;
using CP.ImportExport.Common.Helpers;
using CP.ImportExport.Common.Services;
using CP.ImportExport.LegalEntity.Contract;
using CP.ImportExport.LegalEntity.Models;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Contract.LegalEntity.Models;
using Ninject;

namespace CP.ImportExport.LegalEntity.Services
{
    public class LegalEntityImportExportService :
        ImportExportServiceBase<LegalEntityImportExportModel, LegalEntityModel, LegalEntityView>,
        ILegalEntityImportExportService
    {
        [Inject]
        ICurrencyRetrievingService CurrencyRetrievingService { get; set; }

        public override string GetTemplateName()
        {
            return "LegalEntities";
        }

        public override IEnumerable<LegalEntityModel> Parse(List<LegalEntityImportExportModel> importModels)
        {
            foreach (LegalEntityImportExportModel model in importModels)
            {
                yield return new LegalEntityModel()
                {
                    Id = ImportExportHelper.ParseId(model.Id),
                    Name = model.Name,
                    CurrencyId = CurrencyRetrievingService.Get().First(c => c.Name == model.Currency).Id,
                    IsActive = bool.Parse(model.IsActive)
                };
            }
        }

        public override IEnumerable<LegalEntityImportExportModel> GetExportModels()
        {
            var models = SimpleRetrievingService.Get();
            foreach (LegalEntityView model in models)
            {
                yield return new LegalEntityImportExportModel()
                {
                    Id = model.Id.ToString(),
                    Name = model.Name,
                    Currency = model.Currency.Name,
                    IsActive = model.IsActive.ToString()
                };
            }
        }
    }
}