using System.Collections.Generic;
using CP.ImportExport.Common.Helpers;
using CP.ImportExport.Common.Services;
using CP.ImportExport.Currency.Contract;
using CP.ImportExport.Currency.Models;
using CP.Shared.Contract.Currency.Models;

namespace CP.ImportExport.Currency.Services
{
    public class CurrencyImportExportService : 
        ImportExportServiceBase<CurrencyImportExportModel, CurrencyModel, CurrencyView>, 
        ICurrencyImportExportService
    {
        public override string GetTemplateName()
        {
            return "Currencies";
        }

        public override IEnumerable<CurrencyModel> Parse(List<CurrencyImportExportModel> importModels)
        {
            foreach (CurrencyImportExportModel model in importModels)
            {
                yield return new CurrencyModel()
                {
                    Id = ImportExportHelper.ParseId(model.Id),
                    Name = model.Name
                };
            }
        }

        public override IEnumerable<CurrencyImportExportModel> GetExportModels()
        {
            IEnumerable<CurrencyView> models = SimpleRetrievingService.Get();
            foreach (CurrencyView model in models)
            {
                yield return new CurrencyImportExportModel()
                {
                    Id = model.Id.ToString(),
                    Name = model.Name
                };
            }
        }
    }
}