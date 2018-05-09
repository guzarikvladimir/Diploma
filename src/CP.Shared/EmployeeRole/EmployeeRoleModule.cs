using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Core.Services;
using CP.Shared.Contract.EmployeeRole.Models;
using CP.Shared.Contract.EmployeeRole.Services;
using CP.Shared.EmployeeRole.Mappers;
using CP.Shared.EmployeeRole.Services;
using Ninject;
using Ninject.Web.Common;
using EmployeeRoleEntity = CP.Repository.Models.EmployeeRole;

namespace CP.Shared.EmployeeRole
{
    public class EmployeeRoleModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmployeeRoleRetrievingService>().To<EmployeeRoleRetrievingService>().InRequestScope();
            kernel.Bind<IEmployeeRoleModifyingService, ISimpleModifyingService<EmployeeRoleModel>>()
                .To<EmployeeRoleModifyingService>()
                .InRequestScope();

            kernel.Bind<IEntityMapper<EmployeeRoleEntity, EmployeeRoleView>,
                    IEntityModifyingMapper<EmployeeRoleModel, EmployeeRoleEntity>>()
                .To<EmployeeRoleMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            EmployeeRoleMapper.Register(config);
        }
    }
}