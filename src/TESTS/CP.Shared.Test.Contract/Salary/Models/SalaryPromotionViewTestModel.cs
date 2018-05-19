using CP.Shared.Contract.Salary.Models;
using CP.SpecFlowEx.Test.Models;

namespace CP.Shared.Test.Contract.Salary.Models
{
    public class SalaryPromotionViewTestModel : ITestModel<SalaryPromotionView>
    {
        public string Name { get; set; }

        public SalaryPromotionView Entity { get; set; }
    }
}