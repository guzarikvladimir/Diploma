using System;
using System.Collections.Generic;
using System.Linq;
using CP.Repository.Models;
using CP.Shared.Contract.Compensation.Models;
using CP.Shared.Contract.Compensation.Services;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Contract.EmployeeToLegalEntity.Models;
using CP.Shared.Contract.EmployeeToLegalEntity.Services;
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

        [Inject]
        IEmployeeToLegalEntityRetrievingService EmployeeToLegalEntityRetrievingService { get; set; }

        #endregion

        public ValueWithCurrency Get(List<CompensationPromotionView> compensations, Guid employeeId, Guid? currencyId, 
            DateTime? date = null)
        {
            if (!compensations.Any())
            {
                return null;
            }

            List<CompensationPromotionView> calculatedCompensation = 
                GetCalculatedCompensations(compensations, employeeId);
            CurrencyView currency = CurrencyResolverService.GetResultCurrency(calculatedCompensation, employeeId, 
                currencyId);
            decimal total = 0;
            foreach (CompensationPromotionView compensationPromotion in calculatedCompensation)
            {
                ValueWithCurrency value = CurrencyConverterService.Convert(compensationPromotion.Value, 
                    compensationPromotion.Currency.Id, currency.Id, date);
                SalaryPromotionView salaryPromotion = compensationPromotion as SalaryPromotionView;
                if (salaryPromotion != null && salaryPromotion.SalaryType == SalaryType.Monthly)
                {
                    total += value.Value * 12;

                    continue;
                }

                total += value.Value;
            }

            return new ValueWithCurrency(total, currency);
        }

        private List<CompensationPromotionView> GetCalculatedCompensations(List<CompensationPromotionView> compensations,
            Guid employeeId)
        {
            List<CompensationPromotionView> result = new List<CompensationPromotionView>(
                compensations.Where(cp => cp.PromotionType == CompensationPromotionType.Bonus));
            IEnumerable<EmployeeToLegalEntityView> legalEntities = EmployeeToLegalEntityRetrievingService.Get(employeeId);
            foreach (Guid legalEntityId in legalEntities.Select(el => el.LegalEntity.Id))
            {
                CompensationPromotionView activeSalary = compensations.FirstOrDefault(
                    cp => cp.PromotionType == CompensationPromotionType.Salary && cp.LegalEntity.Id == legalEntityId);
                if (activeSalary != null)
                {
                    result.Add(activeSalary);
                }
            }

            return result;
        }
    }
}