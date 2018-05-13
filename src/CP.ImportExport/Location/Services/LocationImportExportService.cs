using System.Collections.Generic;
using System.Linq;
using CP.ImportExport.Common.Helpers;
using CP.ImportExport.Common.Services;
using CP.ImportExport.Location.Contract;
using CP.ImportExport.Location.Models;
using CP.Shared.Contract.Country.Models;
using CP.Shared.Contract.Country.Services;
using CP.Shared.Contract.Location.Models;
using Ninject;

namespace CP.ImportExport.Location.Services
{
    public class LocationImportExportService :
        ImportExportServiceBase<LocationImportExportModel, LocationModel, LocationView>,
        ILocationImportExportService
    {
        #region Injects

        [Inject]
        ICountryRetrievingService CountryRetrievingService { get; set; }

        [Inject]
        ICountryModifyingService CountryModifyingService { get; set; }

        #endregion

        public override string GetTemplateName()
        {
            return "Locations";
        }

        public override IEnumerable<LocationModel> Parse(List<LocationImportExportModel> importModels)
        {
            AddOrUpdateCountries(importModels);

            foreach (LocationImportExportModel model in importModels)
            {
                yield return new LocationModel()
                {
                    Id = ImportExportHelper.ParseId(model.Id),
                    Name = model.Name,
                    CountryId = CountryRetrievingService.Get().First(c => c.Name == model.Country).Id
                };
            }
        }

        public override IEnumerable<LocationImportExportModel> GetExportModels()
        {
            IEnumerable<LocationView> models = SimpleRetrievingService.Get();
            foreach (LocationView model in models)
            {
                yield return new LocationImportExportModel()
                {
                    Id = model.Id.ToString(),
                    Name = model.Name,
                    Country = model.Country.Name
                };
            }
        }

        public void AddOrUpdateCountries(List<LocationImportExportModel> importModels)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                foreach (string country in importModels.Select(m => m.Country).Distinct())
                {
                    var model = CountryRetrievingService.Get().FirstOrDefault(c => c.Name == country);
                    if (model != null)
                    {
                        continue;
                    }

                    CountryModifyingService.AddOrUpdate(new CountryModel() { Name = country });
                }

                scope.SaveChanges();
            }
        }
    }
}