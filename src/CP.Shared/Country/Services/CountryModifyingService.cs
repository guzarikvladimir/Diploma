using CP.Shared.Contract.Country.Models;
using CP.Shared.Contract.Country.Services;
using CP.Shared.Core.Services;
using CountryEntity = CP.Repository.Models.Country;

namespace CP.Shared.Country.Services
{
    public class CountryModifyingService :
        SimpleModifyingService<CountryEntity, CountryModel>,
        ICountryModifyingService
    {
    }
}