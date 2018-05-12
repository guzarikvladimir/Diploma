using System.Collections.Generic;
using System.Linq;
using CP.ImportExport.Import.Core.Services;
using CP.ImportExport.Import.Location.Contract;
using CP.ImportExport.Import.Location.Models;
using CP.Shared.Contract.Country.Models;
using CP.Shared.Contract.Country.Services;
using CP.Shared.Contract.Location.Models;
using CP.Shared.Contract.Location.Services;
using Ninject;

namespace CP.ImportExport.Import.Location.Services
{
    public class LocationImportService :
        ImportServiceBase<LocationImportModel, LocationModel>,
        ILocationImportService
    {
        #region Injects

        [Inject]
        ICountryRetrievingService CountryRetrievingService { get; set; }

        [Inject]
        ICountryModifyingService CountryModifyingService { get; set; }

        [Inject]
        ILocationRetrievingService LocationRetrievingService { get; set; }

        #endregion

        public override string GetTemplateName()
        {
            return "Locations";
        }

        public override IEnumerable<LocationModel> Parse(List<LocationImportModel> importModels)
        {
            AddOrUpdateCountries(importModels);

            foreach (LocationImportModel model in importModels)
            {
                yield return new LocationModel()
                {
                    Name = model.Name,
                    CountryId = CountryRetrievingService.Get().First(c => c.Name == model.Country).Id
                };
            }
        }

        public override void AddOrUpdate(List<LocationModel> models)
        {
            foreach (LocationModel model in models)
            {
                var existingModel = LocationRetrievingService.Get()
                    .FirstOrDefault(l => l.Name == model.Name && l.Country.Id == model.CountryId);
                if (existingModel != null)
                {
                    continue;
                }

                SimpleModifyingService.Add(model);
            }
        }

        public void AddOrUpdateCountries(List<LocationImportModel> importModels)
        {
            using (var scope = DbFactory.Create())
            {
                foreach (string country in importModels.Select(m => m.Country).Distinct())
                {
                    var model = CountryRetrievingService.Get().FirstOrDefault(c => c.Name == country);
                    if (model != null)
                    {
                        continue;
                    }

                    CountryModifyingService.Add(new CountryModel() { Name = country });
                }

                scope.SaveChanges();
            }
        }
    }
}