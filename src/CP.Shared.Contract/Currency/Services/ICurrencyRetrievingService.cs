using System.Collections.Generic;
using CP.Shared.Contract.Core.Services;
using CP.Shared.Contract.Currency.Models;

namespace CP.Shared.Contract.Currency.Services
{
    public interface ICurrencyRetrievingService : ISimpleRetrievingService<CurrencyView>
    {
        List<CurrencyView> GetOrdered();

        CurrencyView GetDefault();
    }
}