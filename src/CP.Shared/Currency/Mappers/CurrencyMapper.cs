using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Currency.Models;
using CurrencyEntity = CP.Repository.Models.Currency;

namespace CP.Shared.Currency.Mappers
{
    public class CurrencyMapper : 
        IEntityMapper<CurrencyEntity, CurrencyView>,
        IEntityModifyingMapper<CurrencyModel, CurrencyEntity>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<CurrencyEntity, CurrencyView>();
            config.CreateMap<CurrencyModel, CurrencyEntity>();
        }

        public CurrencyView Map(CurrencyEntity model)
        {
            return Mapper.Map<CurrencyView>(model);
        }

        public void Map(CurrencyModel viewModel, CurrencyEntity entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public CurrencyEntity Map(CurrencyModel viewModel)
        {
            return Mapper.Map<CurrencyEntity>(viewModel);
        }
    }
}