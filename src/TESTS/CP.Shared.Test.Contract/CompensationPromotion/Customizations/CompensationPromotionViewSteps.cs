using AutoFixture;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Test.Contract.CompensationPromotion.Helpers;
using CP.Shared.Test.Contract.CompensationPromotion.Models;
using CP.SpecFlowEx.Test.Models;
using CP.SpecFlowEx.Test.Services;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CP.Shared.Test.Contract.CompensationPromotion.Customizations
{
    [Binding]
    public class CompensationPromotionViewSteps : 
        EntitiesStepsBase<CompensationPromotionView, CompensationpromotionViewTestModel>
    {
        public const string Default = @"Compensations are customized to have properties";

        public CompensationPromotionViewSteps(BaseTestData data) : base(data)
        {
        }

        [Given(Default)]
        public void GivenCompensationsAreCustomizedToHaveProperties(Table table)
        {
            foreach (var model in table.CreateSet<CompensationPromotionViewCustomizationModel>())
            {
                CompensationPromotionView compensationPromotion = Fixture.Create<CompensationPromotionView>();
                CompensationpromotionViewTestModel testModel = CompensationPromotionHelper.Map(Fixture, model, 
                    compensationPromotion);
                list.Add(testModel);
            }
        }
    }
}