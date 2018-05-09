using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Country.Models;
using CountryEntity = CP.Repository.Models.Country;

namespace CP.Shared.Country.Mappers
{
    public class CountryMapper : 
        IEntityMapper<CountryEntity, CountryView>,
        IEntityModifyingMapper<CountryModel, CountryEntity>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<CountryEntity, CountryView>();
            config.CreateMap<CountryModel, CountryEntity>();
        }

        public CountryView Map(CountryEntity model)
        {
            return Mapper.Map<CountryView>(model);
        }

        public void Map(CountryModel viewModel, CountryEntity entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public CountryEntity Map(CountryModel viewModel)
        {
            return Mapper.Map<CountryEntity>(viewModel);
        }
    }
}