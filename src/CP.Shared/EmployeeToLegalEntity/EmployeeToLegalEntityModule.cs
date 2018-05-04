using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.EmployeeToLegalEntity.Models;
using CP.Shared.Contract.EmployeeToLegalEntity.Services;
using CP.Shared.EmployeeToLegalEntity.Mappers;
using CP.Shared.EmployeeToLegalEntity.Services;
using Ninject;
using Ninject.Web.Common;
using EmployeeToLegalEntityEntity = CP.Repository.Models.EmployeeToLegalEntity;

namespace CP.Shared.EmployeeToLegalEntity
{
    public class EmployeeToLegalEntityModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmployeeToLegalEntityRetrievingService>()
                .To<EmployeeToLegalEntityRetrievingService>()
                .InRequestScope();
            kernel.Bind<IEmployeeToLegalEntityModifyingService>()
                .To<EmployeeToLegalEntityModifyingService>()
                .InRequestScope();

            kernel.Bind<IEntityMapper<EmployeeToLegalEntityEntity, EmployeeToLegalEntityView>,
                    IEntityModifyingMapper<EmployeeToLegalEntityModel, EmployeeToLegalEntityEntity>>()
                .To<EmployeeToLegalEntityMapper>()
                .InRequestScope();
        }
    }
}