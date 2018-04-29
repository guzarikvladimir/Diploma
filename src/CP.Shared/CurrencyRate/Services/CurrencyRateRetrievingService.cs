using CP.Shared.Contract.CurrencyRate.Models;
using CP.Shared.Contract.CurrencyRate.Services;
using CP.Shared.Core.Services;
using CurrencyRateEntity = CP.Repository.Models.CurrencyRate;

namespace CP.Shared.CurrencyRate.Services
{
    public class CurrencyRateRetrievingService :
        SimpleRetrievingService<CurrencyRateEntity, CurrencyRateView>,
        ICurrencyRateRetrievingService
    {
    }
}