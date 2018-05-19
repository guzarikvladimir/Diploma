using CP.Shared.Contract.CompensationPromotion.Models;
using CP.SpecFlowEx.Test.Models;

namespace CP.Shared.Test.Contract.CompensationPromotion.Models
{
    public class CompensationpromotionViewTestModel : ITestModel<CompensationPromotionView>
    {
        public string Name { get; set; }

        public CompensationPromotionView Entity { get; set; }
    }
}