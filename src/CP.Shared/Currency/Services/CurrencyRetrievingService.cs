using CP.Platform.Crud.Services;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Currency.Services;

namespace CP.Shared.Currency.Services
{
    public class CurrencyRetrievingService :
        SimpleRetrievingService<Repository.Models.Currency, CurrencyView>,
        ICurrencyRetrievingService
    {
    }
}