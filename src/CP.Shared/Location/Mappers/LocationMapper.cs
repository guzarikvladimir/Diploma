using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Country.Services;
using CP.Shared.Contract.Location.Models;
using Ninject;
using LocationEntity = CP.Repository.Models.Location;

namespace CP.Shared.Location.Mappers
{
    public class LocationMapper : IEntityMapper<LocationEntity, LocationView>
    {
        [Inject]
        ICountryRetrievingService CountryRetrievingService { get; set; }

        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<LocationEntity, LocationView>();
        }

        public LocationView Map(LocationEntity model)
        {
            LocationView view = Mapper.Map<LocationView>(model);
            view.Country = CountryRetrievingService.GetById(model.CountryId);

            return view;
        }
    }
}