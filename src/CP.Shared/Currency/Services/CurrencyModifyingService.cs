using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Core.Services;
using CurrencyEntity = CP.Repository.Models.Currency;

namespace CP.Shared.Currency.Services
{
    public class CurrencyModifyingService : 
        SimpleModifyingService<CurrencyEntity, CurrencyModel>,
        ICurrencyModifyingService
    {
    }
}