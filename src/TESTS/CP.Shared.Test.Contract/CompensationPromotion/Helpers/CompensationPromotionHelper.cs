using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Castle.Core.Internal;
using CP.Repository.Models;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.LegalEntity.Models;
using CP.Shared.Test.Contract.CompensationPromotion.Models;
using CP.SpecFlowEx.Test.Helpers;

namespace CP.Shared.Test.Contract.CompensationPromotion.Helpers
{
    public static class CompensationPromotionHelper
    {
        public static CompensationpromotionViewTestModel Map(IFixture fixture, 
            CompensationPromotionViewCustomizationModel model, CompensationPromotionView compensation)
        {
            compensation.Value = decimal.Parse(model.Value);
            compensation.Currency = fixture.Create<List<CurrencyView>>()
                .First(c => c.Name == model.Currency);
            compensation.PromotionType =
                HelperService.ParseEnum<CompensationPromotionType>(model.PromotionType);
            compensation.ApplyDate = HelperService.ParseDate(model.ApplyDate);
            if (!model.Employee.IsNullOrEmpty())
            {
                compensation.Employee = fixture.Create<List<EmployeeView>>()
                    .First(e => e.Name == model.Employee);
            }

            if (!model.LegalEntity.IsNullOrEmpty())
            {
                compensation.LegalEntity = fixture.Create<List<LegalEntityView>>()
                    .First(le => le.Name == model.LegalEntity);
            }

            if (!model.PromotionStatus.IsNullOrEmpty())
            {
                compensation.PromotionStatus =
                    HelperService.ParseEnum<CompensationPromotionStatus>(model.PromotionStatus);
            }

            if (!model.CreatedDate.IsNullOrEmpty())
            {
                compensation.CreatedDate = HelperService.ParseDate(model.CreatedDate);
            }

            return new CompensationpromotionViewTestModel()
            {
                Name = model.Name,
                Entity = compensation
            };
        }

        public static T Map<T>(CompensationPromotionView compensation, T model)
            where T : CompensationPromotionView
        {
            model.Id = compensation.Id;
            model.Value = compensation.Value;
            model.Currency = compensation.Currency;
            model.Employee = compensation.Employee;
            model.PromotionType = compensation.PromotionType;
            model.PromotionStatus = compensation.PromotionStatus;
            model.ApplyDate = compensation.ApplyDate;
            model.CreatedDate = compensation.CreatedDate;
            model.LegalEntity = compensation.LegalEntity;

            return model;
        }
    }
}