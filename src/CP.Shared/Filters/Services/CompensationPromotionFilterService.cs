using System;
using System.Linq.Expressions;
using CP.Platform.RequestTime.Contract;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Filters.Model;
using CP.Shared.Contract.Filters.Services;
using Ninject;

namespace CP.Shared.Filters.Services
{
    public class CompensationPromotionFilterService : ICompensationPromotionFilterService
    {
        [Inject]
        IRequestTime RequestTime { get; set; }

        public Func<CompensationPromotionView, bool> Get(CollectionViewParameters parameters)
        {
            var pageFilterExpression = GetPageFilter(parameters);
            
            return pageFilterExpression.Compile();
        }

        private Expression<Func<CompensationPromotionView, bool>> GetPageFilter(CollectionViewParameters parameters)
        {
            int year = parameters.Year ?? RequestTime.Time.Year;

            return (compensation) => compensation.ApplyDate.Year == year;
        }
    }
}