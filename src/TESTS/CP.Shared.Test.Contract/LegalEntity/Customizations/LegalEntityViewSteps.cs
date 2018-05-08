using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.Platform.Test.Core.Helpers;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.LegalEntity.Models;
using CP.Shared.Test.Contract.LegalEntity.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CP.Shared.Test.Contract.LegalEntity.Customizations
{
    [Binding]
    public class LegalEntityViewSteps : EntityStepsBase<LegalEntityView>
    {
        public LegalEntityViewSteps(BaseTestData data) : base(data)
        {
        }

        [Given(@"LegalEntities are customized to have properties")]
        public void GivenLegalEntitiesAreCustomizedToHaveProperties(Table table)
        {
            foreach (var model in table.CreateSet<LegalEntityViewCustomizationModel>())
            {
                LegalEntityView legalEntity = Fixture.Create<LegalEntityView>();
                legalEntity.Name = model.Name;
                legalEntity.Currency = Fixture.Create<List<CurrencyView>>().First(c => c.Name == model.Currency);
                legalEntity.IsActive = HelperService.ParseBool(model.IsActive);
                list.Add(legalEntity);
            }
        }
    }
}