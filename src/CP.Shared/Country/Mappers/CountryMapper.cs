using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Country.Models;
using CountryEntity = CP.Repository.Models.Country;

namespace CP.Shared.Country.Mappers
{
    public class CountryMapper : IEntityMapper<CountryEntity, CountryView>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<CountryEntity, CountryView>();
        }

        public CountryView Map(CountryEntity model)
        {
            return Mapper.Map<CountryView>(model);
        }
    }
}