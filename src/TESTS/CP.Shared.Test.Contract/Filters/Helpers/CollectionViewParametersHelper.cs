using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Castle.Core.Internal;
using CP.Platform.Test.Core.Helpers;
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

            if (!HelperService.IsNull(model.Page))
            {
                parameters.Page = int.Parse(model.Page);
            }

            if (!HelperService.IsNull(model.PageCount))
            {
                parameters.PageCount = int.Parse(model.PageCount);
            }

            if (!HelperService.IsNull(model.Year))
            {
                parameters.Year = int.Parse(model.Year);
            }

            if (!HelperService.IsNull(model.Currency))
            {
                parameters.CurrencyId = fixture.Create<List<CurrencyView>>()
                    .First(c => c.Name == model.Currency).Id;
            }

            return parameters;
        }
    }
}