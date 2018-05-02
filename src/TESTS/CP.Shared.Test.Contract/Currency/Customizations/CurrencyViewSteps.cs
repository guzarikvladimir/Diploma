using AutoFixture;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Contract.Currency.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CP.Shared.Test.Contract.Currency.Customizations
{
    [Binding]
    public class CurrencyViewSteps : EntityStepsBase<CurrencyView>
    {
        public CurrencyViewSteps(BaseTestData data) : base(data)
        {
        }

        [Given(@"Currencies are customized to have properties")]
        public void GivenCurrenciesAreConfiguredToHaveProperties(Table table)
        {
            foreach (CurrencyView model in table.CreateSet<CurrencyView>())
            {
                CurrencyView currency = Fixture.Create<CurrencyView>();
                currency.Name = model.Name;
                list.Add(currency);
            }
        }
    }
}