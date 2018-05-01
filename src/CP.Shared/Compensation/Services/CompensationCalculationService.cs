using System;
using System.Collections.Generic;
using System.Linq;
using CP.Repository.Models;
using CP.Shared.Contract.Compensation.Models;
using CP.Shared.Contract.Compensation.Services;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Contract.Salary.Models;
using Ninject;

namespace CP.Shared.Compensation.Services
{
    public class CompensationCalculationService : ICompensationCalculationService
    {
        #region Injects

        [Inject]
        ICurrencyResolverService CurrencyResolverService { get; set; }

        [Inject]
        ICurrencyConverterService CurrencyConverterService { get; set; }

        #endregion

        public ValueWithCurrency Get(List<CompensationPromotionView> compensations, DateTime? date = null)
        {
            if (!compensations.Any())
            {
                return null;
            }

            CurrencyView currency = CurrencyResolverService.GetResultCurrency(compensations);
            decimal total = 0;
            foreach (CompensationPromotionView compensationPromotion in compensations)
            {
                ValueWithCurrency value = CurrencyConverterService.Convert(compensationPromotion, currency.Id, date);
                SalaryPromotionView salaryPromotion = compensationPromotion as SalaryPromotionView;
                if (salaryPromotion != null && salaryPromotion.SalaryType == SalaryType.Monthly)
                {
                    total += value.Value * 12;
                }

                total += value.Value;
            }

            return new ValueWithCurrency()
            {
                Value = total,
                Currency = currency
            };
        }
    }
}