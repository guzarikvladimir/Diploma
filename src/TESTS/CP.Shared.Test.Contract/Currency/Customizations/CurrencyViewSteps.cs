using AutoFixture;
using CP.Shared.Contract.Currency.Models;
using CP.SpecFlowEx.Test.Models;
using CP.SpecFlowEx.Test.Services;
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