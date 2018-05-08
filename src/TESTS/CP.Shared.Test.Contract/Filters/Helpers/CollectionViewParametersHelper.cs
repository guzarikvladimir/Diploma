using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Castle.Core.Internal;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Filters.Model;
using CP.Shared.Test.Contract.Filters.Models;

namespace CP.Shared.Test.Contract.Filters.Helpers
{
    public static class CollectionViewParametersHelper
    {
        public static T Map<T>(IFixture fixture, CollectionViewParametersCustomizationModel model)
            where T : CollectionViewParameters, new()
        {
            T parameters = new T();

            if (!model.Page.IsNullOrEmpty())
            {
                parameters.Page = int.Parse(model.Page);
            }

            if (!model.PageCount.IsNullOrEmpty())
            {
                parameters.PageCount = int.Parse(model.PageCount);
            }

            if (!model.Year.IsNullOrEmpty())
            {
                parameters.Year = int.Parse(model.Year);
            }

            if (!model.Currency.IsNullOrEmpty())
            {
                parameters.CurrencyId = fixture.Create<List<CurrencyView>>()
                    .First(c => c.Name == model.Currency).Id;
            }

            return parameters;
        }
    }
}