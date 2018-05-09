using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Core.Services;
using CP.Shared.Contract.LegalEntity.Models;
using CP.Shared.Contract.LegalEntity.Services;
using CP.Shared.LegalEntity.Mappers;
using CP.Shared.LegalEntity.Services;
using Ninject;
using Ninject.Web.Common;
using LegalEntityEntity = CP.Repository.Models.LegalEntity;

namespace CP.Shared.LegalEntity
{
    public class LegalEntityModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILegalEntityRetrievingService>().To<LegalEntityRetrievingService>().InRequestScope();
            kernel.Bind<ILegalEntityModifyingService, ISimpleModifyingService<LegalEntityModel>>()
                .To<LegalEntityModifyingService>()
                .InRequestScope();

            kernel.Bind<IEntityMapper<LegalEntityEntity, LegalEntityView>,
                    IEntityModifyingMapper<LegalEntityModel, LegalEntityEntity>>()
                .To<LegalEntityMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            LegalEntityMapper.Register(config);
        }
    }
}