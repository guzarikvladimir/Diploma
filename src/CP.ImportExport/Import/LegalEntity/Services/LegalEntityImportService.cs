using System.Collections.Generic;
using System.Linq;
using CP.ImportExport.Import.Core.Services;
using CP.ImportExport.Import.LegalEntity.Contract;
using CP.ImportExport.Import.LegalEntity.Models;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Contract.LegalEntity.Models;
using CP.Shared.Contract.LegalEntity.Services;
using Ninject;

namespace CP.ImportExport.Import.LegalEntity.Services
{
    public class LegalEntityImportService :
        ImportServiceBase<LegalEntityImportModel, LegalEntityModel>,
        ILegalEntityImportService
    {
        #region Injects

        [Inject]
        ICurrencyRetrievingService CurrencyRetrievingService { get; set; }

        [Inject]
        ILegalEntityRetrievingService LegalEntityRetrievingService { get; set; }

        #endregion

        public override string GetTemplateName()
        {
            return "LegalEntities";
        }

        public override IEnumerable<LegalEntityModel> Parse(List<LegalEntityImportModel> importModels)
        {
            foreach (LegalEntityImportModel model in importModels)
            {
                yield return new LegalEntityModel()
                {
                    Name = model.Name,
                    CurrencyId = CurrencyRetrievingService.Get().First(c => c.Name == model.Currency).Id,
                    IsActive = bool.Parse(model.IsActive)
                };
            }
        }

        public override void AddOrUpdate(List<LegalEntityModel> models)
        {
            foreach (LegalEntityModel model in models)
            {
                var existingModel = LegalEntityRetrievingService.Get()
                    .FirstOrDefault(le => le.Name == model.Name);
                if (existingModel != null)
                {
                    model.Id = existingModel.Id;
                    SimpleModifyingService.Update(model);

                    continue;
                }

                SimpleModifyingService.Add(model);
            }
        }
    }
}