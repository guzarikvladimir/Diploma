using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Core.Services;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Currency.Mappers;
using CP.Shared.Currency.Services;
using Ninject;
using Ninject.Web.Common;
using CurrencyEntity = CP.Repository.Models.Currency;

namespace CP.Shared.Currency
{
    public class CurrenyModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICurrencyRetrievingService>().To<CurrencyRetrievingService>().InRequestScope();
            kernel.Bind<ICurrencyService>().To<CurrencyService>().InRequestScope();
            kernel.Bind<ICurrencyResolverService>().To<CurrencyResolverService>().InRequestScope();
            kernel.Bind<ISimpleModifyingService<CurrencyModel>, ICurrencyModifyingService>()
                .To<CurrencyModifyingService>()
                .InRequestScope();
            kernel.Bind<ICurrencyConverterService>().To<CurrencyConverterService>().InRequestScope();

            kernel.Bind<IEntityMapper<CurrencyEntity, CurrencyView>,
                    IEntityModifyingMapper<CurrencyModel, CurrencyEntity>>()
                .To<CurrencyMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            CurrencyMapper.Register(config);
        }
    }
}