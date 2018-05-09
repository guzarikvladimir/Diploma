using System;
using System.Collections.Generic;
using System.Linq;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Contract.EmployeeLegalEntity.Models;
using CP.Shared.Contract.EmployeeLegalEntity.Services;
using CP.Shared.Contract.LegalEntity.Models;
using Ninject;

namespace CP.Shared.Currency.Services
{
    public class CurrencyResolverService : ICurrencyResolverService
    {
        #region Injects

        [Inject]
        ICurrencyService CurrencyService { get; set; }

        [Inject]
        ICurrencyRetrievingService CurrencyRetrievingService { get; set; }

        [Inject]
        IEmployeeLegalEntityRetrievingService EmployeeLegalEntityRetrievingService { get; set; }

        #endregion

        public CurrencyView GetResultCurrency(List<CompensationPromotionView> compensations, Guid employeeId, 
            Guid? currencyId)
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

            IEnumerable<EmployeeLegalEntityView> employeeLegalEntities = EmployeeLegalEntityRetrievingService
                .Get(employeeId);
            LegalEntityView legalEntity = employeeLegalEntities
                .FirstOrDefault(el => el.IsPrimary && el.LegalEntity.IsActive)?.LegalEntity;
            if (legalEntity != null)
            {
                return legalEntity.Currency;
            }

            return CurrencyService.GetDefault();
        }
    }
}