using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Contract.CurrencyRate.Models;
using Ninject;
using CurrencyRateEntity = CP.Repository.Models.CurrencyRate;

namespace CP.Shared.CurrencyRate.Mappers
{
    public class CurrencyRateMapper : IEntityMapper<CurrencyRateEntity, CurrencyRateView>
    {
        [Inject]
        ICurrencyRetrievingService CurrencyRetrievingService { get; set; }

        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<CurrencyRateEntity, CurrencyRateView>();
        }

        public CurrencyRateView Map(CurrencyRateEntity model)
        {
            CurrencyRateView view = Mapper.Map<CurrencyRateView>(model);
            view.Currency = CurrencyRetrievingService.GetById(model.CurrencyId);

            return view;
        }
    }
}