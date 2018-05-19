using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.Repository.Models;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Salary.Models;
using CP.Shared.Test.Contract.CompensationPromotion.Helpers;
using CP.Shared.Test.Contract.CompensationPromotion.Models;
using CP.Shared.Test.Contract.Salary.Models;
using CP.SpecFlowEx.Test.Helpers;

namespace CP.Shared.Test.Contract.Salary.Helpers
{
    public static class SalaryPromotionHelper
    {
        public static SalaryPromotionViewTestModel Map(IFixture fixture,
            SalaryPromotionViewCustomizationModel model, SalaryPromotionView salary)
        {
            salary.SalaryType = HelperService.ParseEnum<SalaryType>(model.SalaryType);
            CompensationPromotionView compensation = fixture.Create<List<CompensationpromotionViewTestModel>>()
                .First(cp => cp.Name == model.Name).Entity;
            CompensationPromotionHelper.Map(compensation, salary);

            return new SalaryPromotionViewTestModel()
            {
                Name = model.Name,
                Entity = salary
            };
        }
    }
}