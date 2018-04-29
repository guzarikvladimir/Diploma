using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Location.Models;
using CP.Shared.Contract.Location.Services;
using CP.Shared.Location.Mappers;
using CP.Shared.Location.Services;
using Ninject;
using Ninject.Web.Common;
using LocationEntity = CP.Repository.Models.Location;

namespace CP.Shared.Location
{
    public class LocationModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILocationRetrievingService>().To<LocationRetrievingService>().InRequestScope();

            kernel.Bind<IEntityMapper<LocationEntity, LocationView>>().To<LocationMapper>().InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            LocationMapper.Register(config);
        }
    }
}