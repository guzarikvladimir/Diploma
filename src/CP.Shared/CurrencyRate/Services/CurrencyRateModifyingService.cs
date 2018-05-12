using CP.Platform.Crud.Services;
using CP.Shared.Contract.CurrencyRate.Models;
using CP.Shared.Contract.CurrencyRate.Services;
using CurrencyRateEntity = CP.Repository.Models.CurrencyRate;

namespace CP.Shared.CurrencyRate.Services
{
    public class CurrencyRateModifyingService :
        SimpleModifyingService<CurrencyRateEntity, CurrencyRateModel>,
        ICurrencyRateModifyingService
    {
    }
}