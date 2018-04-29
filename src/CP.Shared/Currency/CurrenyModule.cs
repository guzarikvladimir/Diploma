using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Currency.Mappers;
using CP.Shared.Currency.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.Shared.Currency
{
    public class CurrenyModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICurrencyRetrievingService>().To<CurrencyRetrievingService>().InRequestScope();

            kernel.Bind<IEntityMapper<Repository.Models.Currency, CurrencyView>>()
                .To<CurrencyMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            CurrencyMapper.Register(config);
        }
    }
}