using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Country.Services;
using CP.Shared.Contract.Location.Models;
using Ninject;
using LocationEntity = CP.Repository.Models.Location;

namespace CP.Shared.Location.Mappers
{
    public class LocationMapper : 
        IEntityMapper<LocationEntity, LocationView>,
        IEntityModifyingMapper<LocationModel, LocationEntity>
    {
        [Inject]
        ICountryRetrievingService CountryRetrievingService { get; set; }

        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<LocationEntity, LocationView>();
            config.CreateMap<LocationModel, LocationEntity>();
        }

        public LocationView Map(LocationEntity model)
        {
            LocationView view = Mapper.Map<LocationView>(model);
            view.Country = CountryRetrievingService.GetById(model.CountryId);

            return view;
        }

        public void Map(LocationModel viewModel, LocationEntity entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public LocationEntity Map(LocationModel viewModel)
        {
            return Mapper.Map<LocationEntity>(viewModel);
        }
    }
}