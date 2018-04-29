using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Currency.Models;

namespace CP.Shared.Currency.Mappers
{
    public class CurrencyMapper : IEntityMapper<Repository.Models.Currency, CurrencyView>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<Repository.Models.Currency, CurrencyView>();
        }

        public CurrencyView Map(Repository.Models.Currency model)
        {
            return Mapper.Map<CurrencyView>(model);
        }
    }
}