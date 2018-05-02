using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using CP.Shared.Contract.Bonus.Models;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Test.Contract.Bonus.Models;
using CP.Shared.Test.Contract.CompensationPromotion.Helpers;
using CP.Shared.Test.Contract.CompensationPromotion.Models;

namespace CP.Shared.Test.Contract.Bonus.Helpers
{
    public static class BonusPromotionHelper
    {
        public static BonusPromotionViewTestModel Map(IFixture fixture,
            BonusPromotionViewCustomizationModel model, BonusPromotionView bonus)
        {
            CompensationPromotionView compensation = fixture.Create<List<CompensationpromotionViewTestModel>>()
                .First(cp => cp.Name == model.Name).Entity;
            CompensationPromotionHelper.Map(compensation, bonus);

            return new BonusPromotionViewTestModel()
            {
                Name = model.Name,
                Entity = bonus
            };
        }
    }
}