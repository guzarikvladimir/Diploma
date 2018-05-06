using System;
using System.Collections.Generic;
using System.Linq;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Currency.Services;
using Ninject;

namespace CP.Shared.Currency.Services
{
    public class CurrencyResolverService : ICurrencyResolverService
    {
        [Inject]
        ICurrencyRetrievingService CurrencyRetrievingService { get; set; }

        public CurrencyView GetResultCurrency(List<CompensationPromotionView> compensations, Guid? currencyId)
        {
            if (currencyId.HasValue)
            {
                return CurrencyRetrievingService.GetById(currencyId.Value);
            }

            var groupedByCurrency = compensations.GroupBy(cp => cp.Currency).ToList();
            if (groupedByCurrency.Count == 1)
            {
                return groupedByCurrency.First().Key;
            }

            return CurrencyRetrievingService.GetDefault();
        }
    }
}