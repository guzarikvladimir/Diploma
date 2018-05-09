using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Country.Models;
using CP.Shared.Contract.Country.Services;
using CP.Shared.Country.Mappers;
using CP.Shared.Country.Services;
using Ninject;
using Ninject.Web.Common;
using CountryEntity = CP.Repository.Models.Country;

namespace CP.Shared.Country
{
    public class CountryModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICountryRetrievingService>().To<CountryRetrievingService>().InRequestScope();
            kernel.Bind<ICountryModifyingService>().To<CountryModifyingService>().InRequestScope();

            kernel.Bind<IEntityMapper<CountryEntity, CountryView>, 
                    IEntityModifyingMapper<CountryModel, CountryEntity>>()
                .To<CountryMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            CountryMapper.Register(config);
        }
    }
}