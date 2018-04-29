using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Contract.CurrencyRate.Models;
using CP.Shared.Currency.Services;
using CP.Shared.CurrencyRate.Mappers;
using Ninject;
using Ninject.Web.Common;
using CurrencyRateEntity = CP.Repository.Models.CurrencyRate;

namespace CP.Shared.CurrencyRate
{
    public class CurrencyRateModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICurrencyRetrievingService>().To<CurrencyRetrievingService>().InRequestScope();

            kernel.Bind<IEntityMapper<CurrencyRateEntity, CurrencyRateView>>()
                .To<CurrencyRateMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            CurrencyRateMapper.Register(config);
        }
    }
}