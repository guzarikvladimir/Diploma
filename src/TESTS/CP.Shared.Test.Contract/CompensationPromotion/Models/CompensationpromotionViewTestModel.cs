using CP.Platform.Test.Core.Models;
using CP.Shared.Contract.CompensationPromotion.Models;

namespace CP.Shared.Test.Contract.CompensationPromotion.Models
{
    public class CompensationpromotionViewTestModel : ITestModel<CompensationPromotionView>
    {
        public string Name { get; set; }

        public CompensationPromotionView Entity { get; set; }
    }
}