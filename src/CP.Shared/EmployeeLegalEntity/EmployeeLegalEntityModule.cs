using CP.Platform.Crud.Contract;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.EmployeeLegalEntity.Models;
using CP.Shared.Contract.EmployeeLegalEntity.Services;
using CP.Shared.EmployeeLegalEntity.Mappers;
using CP.Shared.EmployeeLegalEntity.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.Shared.EmployeeLegalEntity
{
    public class EmployeeLegalEntityModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmployeeLegalEntityRetrievingService>()
                .To<EmployeeLegalEntityRetrievingService>()
                .InRequestScope();
            kernel.Bind<IEmployeeLegalEntityModifyingService, ISimpleModifyingService<EmployeeLegalEntityModel>>()
                .To<EmployeeLegalEntityModifyingService>()
                .InRequestScope();

            kernel.Bind<IEntityMapper<Repository.Models.EmployeeLegalEntity, EmployeeLegalEntityView>,
                    IEntityModifyingMapper<EmployeeLegalEntityModel, Repository.Models.EmployeeLegalEntity>>()
                .To<EmployeeLegalEntityMapper>()
                .InRequestScope();
        }
    }
}