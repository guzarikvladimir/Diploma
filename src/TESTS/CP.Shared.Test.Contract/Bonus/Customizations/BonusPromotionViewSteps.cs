using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.Platform.Test.Core.Models;
using CP.Platform.Test.Core.Services;
using CP.Shared.Contract.Bonus.Models;
using CP.Shared.Test.Contract.Bonus.Helpers;
using CP.Shared.Test.Contract.Bonus.Models;
using CP.Shared.Test.Contract.CompensationPromotion.Customizations;
using CP.Shared.Test.Contract.CompensationPromotion.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CP.Shared.Test.Contract.Bonus.Customizations
{
    [Binding]
    public class BonusPromotionViewSteps : 
        EntitiesStepsBase<BonusPromotionView, BonusPromotionViewTestModel>
    {
        public BonusPromotionViewSteps(BaseTestData data) : base(data)
        {
            Fixture.Register(() => list);
        }

        [Given(@"Bonuses are customized to have properties")]
        public void GivenBonusesAreCustomizedToHaveProperties(Table table)
        {
            Given(CompensationPromotionViewSteps.Default, table);
            foreach (var model in table.CreateSet<BonusPromotionViewCustomizationModel>())
            {
                var bonus = Fixture.Create<BonusPromotionView>();
                BonusPromotionViewTestModel testModel = BonusPromotionHelper.Map(Fixture, model, bonus);
                list.Add(testModel);
            }
        }
    }
}