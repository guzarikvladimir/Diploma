using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CP.ImportExport.Common.Helpers;
using CP.ImportExport.Common.Services;
using CP.ImportExport.CurrencyRate.Contract;
using CP.ImportExport.CurrencyRate.Models;
using CP.Platform.Helpers;
using CP.Repository.Models;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Contract.CurrencyRate.Models;
using Ninject;

namespace CP.ImportExport.CurrencyRate.Service
{
    public class CurrencyRateImportExportService :
        ImportExportServiceBase<CurrencyRateImportExportModel, CurrencyRateModel, CurrencyRateView>,
        ICurrencyRateImportExportService
    {
        [Inject]
        ICurrencyRetrievingService CurrencyRetrievingService { get; set; }

        public override string GetTemplateName()
        {
            return "CurrencyRates";
        }

        public override IEnumerable<CurrencyRateModel> Parse(List<CurrencyRateImportExportModel> importModels)
        {
            foreach (CurrencyRateImportExportModel model in importModels)
            {
                yield return new CurrencyRateModel()
                {
                    Id = ImportExportHelper.ParseId(model.Id),
                    CurrencyId = CurrencyRetrievingService.Get().First(c => c.Name == model.Currency).Id,
                    Ratio = decimal.Parse(model.Ratio),
                    Date = HelperService.ParseDate(model.Date),
                    Type = HelperService.ParseEnum<CurrencyRateType>(model.Type)
                };
            }
        }

        public override IEnumerable<CurrencyRateImportExportModel> GetExportModels()
        {
            IEnumerable<CurrencyRateView> models = SimpleRetrievingService.Get();
            foreach (CurrencyRateView model in models)
            {
                yield return new CurrencyRateImportExportModel()
                {
                    Id = model.Id.ToString(),
                    Currency = model.Currency.Name,
                    Ratio = model.Ratio.ToString(CultureInfo.InvariantCulture),
                    Date = model.Date.ToShortDateString(),
                    Type = model.Type.ToString()
                };
            }
        }
    }
}