using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Core.Services;
using CP.Shared.Contract.Role.Models;
using CP.Shared.Contract.Role.Services;
using CP.Shared.Role.Mappers;
using CP.Shared.Role.Services;
using Ninject;
using Ninject.Web.Common;
using RoleEntity = CP.Repository.Models.Role;

namespace CP.Shared.Role
{
    public class RoleModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IRoleRetrievingService>().To<RoleRetrievingService>().InRequestScope();
            kernel.Bind<IRoleModifyingService, ISimpleModifyingService<RoleModel>>()
                .To<RoleModifyingService>()
                .InRequestScope();

            kernel.Bind<IEntityMapper<RoleEntity, RoleView>, IEntityModifyingMapper<RoleModel, RoleEntity>>()
                .To<RoleMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            RoleMapper.Register(config);
        }
    }
}