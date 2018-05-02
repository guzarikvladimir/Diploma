using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.Platform.Test.Core.Helpers;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Repository.Models;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.CurrencyRate.Models;
using CP.Shared.Test.Contract.CurrencyRate.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CP.Shared.Test.Contract.CurrencyRate.Customizations
{
    [Binding]
    public class CurrencyRateViewSteps : EntityStepsBase<CurrencyRateView>
    {
        public CurrencyRateViewSteps(BaseTestData data) : base(data)
        {
        }

        [Given("CurrencyRates are customized to have properties")]
        public void GivenCurrencyRatesAreConfiguredToHaveProperties(Table table)
        {
            foreach (var model in table.CreateSet<CurrencyRateViewCustomizationModel>())
            {
                CurrencyRateView currencyRate = Fixture.Create<CurrencyRateView>();
                currencyRate.Currency = Fixture.Create<List<CurrencyView>>()
                    .FirstOrDefault(cr => cr.Name == model.Currency);
                currencyRate.Ratio = decimal.Parse(model.Ratio);
                currencyRate.Type = HelperService.ParseEnum<CurrencyRateType>(model.Type);
                currencyRate.Date = HelperService.ParseDate(model.Date);
                list.Add(currencyRate);
            }
        }
    }
}