using CP.Platform.Test.Core.Models;
using CP.Shared.Contract.Bonus.Models;

namespace CP.Shared.Test.Contract.Bonus.Models
{
    public class BonusPromotionViewTestModel : ITestModel<BonusPromotionView>
    {
        public string Name { get; set; }

        public BonusPromotionView Entity { get; set; }
    }
}