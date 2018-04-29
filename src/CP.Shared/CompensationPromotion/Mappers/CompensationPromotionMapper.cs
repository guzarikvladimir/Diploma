﻿using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Contract.Employee.Services;
using Ninject;
using CompensationPromotionEntity = CP.Repository.Models.CompensationPromotion;

namespace CP.Shared.CompensationPromotion.Mappers
{
    public class CompensationPromotionMapper : 
        IEntityMapper<CompensationPromotionEntity, CompensationPromotionView>
    {
        #region Injects

        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        [Inject]
        ICurrencyRetrievingService CurrencyRetrievingService { get; set; }

        #endregion

        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<CompensationPromotionEntity, CompensationPromotionView>();
        }

        public CompensationPromotionView Map(CompensationPromotionEntity model)
        {
            CompensationPromotionView view = Mapper.Map<CompensationPromotionView>(model);
            view.Employee = EmployeeRetrievingService.GetById(model.EmployeeId);
            view.Currency = CurrencyRetrievingService.GetById(model.CurrencyId);

            return view;
        }
    }
}