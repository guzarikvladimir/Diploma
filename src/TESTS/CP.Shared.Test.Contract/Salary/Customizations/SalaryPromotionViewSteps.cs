using AutoFixture;
using CP.Shared.Contract.Salary.Models;
using CP.Shared.Test.Contract.CompensationPromotion.Customizations;
using CP.Shared.Test.Contract.Salary.Helpers;
using CP.Shared.Test.Contract.Salary.Models;
using CP.SpecFlowEx.Test.Models;
using CP.SpecFlowEx.Test.Services;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CP.Shared.Test.Contract.Salary.Customizations
{
    [Binding]
    public class SalaryPromotionViewSteps : 
        EntitiesStepsBase<SalaryPromotionView, SalaryPromotionViewTestModel>
    {
        public SalaryPromotionViewSteps(BaseTestData data) : base(data)
        {
        }

        [Given(@"Salaries are customized to have properties")]
        public void GivenSalariesAreCustomizedToHaveProperties(Table table)
        {
            Given(CompensationPromotionViewSteps.Default, table);
            foreach (var model in table.CreateSet<SalaryPromotionViewCustomizationModel>())
            {
                SalaryPromotionView salary = Fixture.Create<SalaryPromotionView>();
                SalaryPromotionViewTestModel testModel = SalaryPromotionHelper.Map(Fixture, model, salary);
                list.Add(testModel);
            }
        }
    }
}