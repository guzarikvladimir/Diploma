using AutoMapper;
using CP.Platform.Crud.Contract;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.CurrencyRate.Models;
using CP.Shared.Contract.CurrencyRate.Services;
using CP.Shared.CurrencyRate.Mappers;
using CP.Shared.CurrencyRate.Services;
using Ninject;
using Ninject.Web.Common;
using CurrencyRateEntity = CP.Repository.Models.CurrencyRate;

namespace CP.Shared.CurrencyRate
{
    public class CurrencyRateModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICurrencyRateRetrievingService>().To<CurrencyRateRetrievingService>().InRequestScope();
            kernel.Bind<ICurrencyRateModifyingService, ISimpleModifyingService<CurrencyRateModel>>()
                .To<CurrencyRateModifyingService>()
                .InRequestScope();
            kernel.Bind<ICurrencyRateService>().To<CurrencyRateService>().InRequestScope();

            kernel.Bind<IEntityMapper<CurrencyRateEntity, CurrencyRateView>,
                    IEntityModifyingMapper<CurrencyRateModel, CurrencyRateEntity>>()
                .To<CurrencyRateMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            CurrencyRateMapper.Register(config);
        }
    }
}