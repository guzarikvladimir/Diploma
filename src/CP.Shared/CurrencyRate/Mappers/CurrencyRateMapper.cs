using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Contract.CurrencyRate.Models;
using Ninject;
using CurrencyRateEntity = CP.Repository.Models.CurrencyRate;

namespace CP.Shared.CurrencyRate.Mappers
{
    public class CurrencyRateMapper : 
        IEntityMapper<CurrencyRateEntity, CurrencyRateView>,
        IEntityModifyingMapper<CurrencyRateModel, CurrencyRateEntity>
    {
        [Inject]
        ICurrencyRetrievingService CurrencyRetrievingService { get; set; }

        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<CurrencyRateEntity, CurrencyRateView>();
            config.CreateMap<CurrencyRateModel, CurrencyRateEntity>();
        }

        public CurrencyRateView Map(CurrencyRateEntity model)
        {
            CurrencyRateView view = Mapper.Map<CurrencyRateView>(model);
            view.Currency = CurrencyRetrievingService.GetById(model.CurrencyId);

            return view;
        }

        public void Map(CurrencyRateModel viewModel, CurrencyRateEntity entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public CurrencyRateEntity Map(CurrencyRateModel viewModel)
        {
            return Mapper.Map<CurrencyRateEntity>(viewModel);
        }
    }
}