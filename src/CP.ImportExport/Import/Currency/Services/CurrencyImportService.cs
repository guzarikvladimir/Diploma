using System.Collections.Generic;
using System.Linq;
using CP.ImportExport.Import.Core.Services;
using CP.ImportExport.Import.Currency.Contract;
using CP.ImportExport.Import.Currency.Models;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Currency.Services;
using Ninject;

namespace CP.ImportExport.Import.Currency.Services
{
    public class CurrencyImportService : 
        ImportServiceBase<CurrencyImportModel, CurrencyModel>, 
        ICurrencyImportService
    {
        [Inject]
        ICurrencyRetrievingService CurrencyRetrievingService { get; set; }

        public override IEnumerable<CurrencyModel> Parse(List<CurrencyImportModel> importModels)
        {
            foreach (CurrencyImportModel importModel in importModels)
            {
                yield return new CurrencyModel()
                {
                    Name = importModel.Name
                };
            }
        }

        public override void AddOrUpdate(List<CurrencyModel> models)
        {
            foreach (CurrencyModel model in models)
            {
                var existingModel = CurrencyRetrievingService.Get().FirstOrDefault(c => c.Name == model.Name);
                if (existingModel != null)
                {
                    continue;
                }

                SimpleModifyingService.Add(model);
            }
        }
    }
}