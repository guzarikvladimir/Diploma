using CP.Shared.Contract.Bonus.Models;
using CP.SpecFlowEx.Test.Models;

namespace CP.Shared.Test.Contract.Bonus.Models
{
    public class BonusPromotionViewTestModel : ITestModel<BonusPromotionView>
    {
        public string Name { get; set; }

        public BonusPromotionView Entity { get; set; }
    }
}