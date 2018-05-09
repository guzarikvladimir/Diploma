using System;
using System.Collections.Generic;
using System.Linq;
using CP.ImportExport.Import.Core.Services;
using CP.ImportExport.Import.CurrencyRate.Contract;
using CP.ImportExport.Import.CurrencyRate.Models;
using CP.Platform.Helpers;
using CP.Repository.Models;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Contract.CurrencyRate.Models;
using Ninject;

namespace CP.ImportExport.Import.CurrencyRate.Service
{
    public class CurrencyRateImportService :
        ImportServiceBase<CurrencyRateImportModel, CurrencyRateModel>,
        ICurrencyRateImportService
    {
        [Inject]
        ICurrencyRetrievingService CurrencyRetrievingService { get; set; }

        public override IEnumerable<CurrencyRateModel> Parse(List<CurrencyRateImportModel> importModels)
        {
            foreach (CurrencyRateImportModel model in importModels)
            {
                yield return new CurrencyRateModel()
                {
                    CurrencyId = CurrencyRetrievingService.Get().First(c => c.Name == model.Currency).Id,
                    Ratio = decimal.Parse(model.Ratio),
                    Date = HelperService.ParseDate(model.Date),
                    Type = HelperService.ParseEnum<CurrencyRateType>(model.Type)
                };
            }
        }

        public override void AddOrUpdate(List<CurrencyRateModel> models)
        {
            foreach (CurrencyRateModel model in models)
            {
                SimpleModifyingService.Add(model);
            }
        }
    }
}