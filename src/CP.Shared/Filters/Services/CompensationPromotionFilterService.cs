using System;
using System.Linq.Expressions;
using CP.Platform.ExpressionEx.Models;
using CP.Platform.RequestTime.Contract;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Contract.Filters.Model;
using CP.Shared.Contract.Filters.Services;
using Ninject;

namespace CP.Shared.Filters.Services
{
    public class CompensationPromotionFilterService : ICompensationPromotionFilterService
    {
        #region Injects

        [Inject]
        IRequestTime RequestTime { get; set; }

        [Inject]
        ICurrencyRetrievingService CurrencyRetrievingService { get; set; }

        #endregion

        public Func<CompensationPromotionView, bool> Get(CollectionViewParameters parameters)
        {
            var pageFilterExpression = new ExpressionEx<CompensationPromotionView>(GetPageFilter(parameters));
            var currencyFilterExpression = new ExpressionEx<CompensationPromotionView>(GetCurrencyFilter(parameters));
            
            return ExpressionEx<CompensationPromotionView>.And(pageFilterExpression, currencyFilterExpression).Compile();
        }

        private Expression<Func<CompensationPromotionView, bool>> GetPageFilter(CollectionViewParameters parameters)
        {
            int year = parameters.Year ?? RequestTime.Time.Year;

            return (compensation) => compensation.ApplyDate.Year == year;
        }

        // ToDo: Dont need it
        private Expression<Func<CompensationPromotionView, bool>> GetCurrencyFilter(CollectionViewParameters parameters)
        {
            Guid currencyId = parameters.CurrencyId ?? CurrencyRetrievingService.GetDefault().Id;

            return (compensation) => compensation.Currency.Id == currencyId;
        }
    }
}