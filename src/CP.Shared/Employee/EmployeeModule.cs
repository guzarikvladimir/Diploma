using AutoMapper;
using CP.Platform.Crud.Contract;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Employee.Mappers;
using CP.Shared.Employee.Services;
using Ninject;
using Ninject.Web.Common;
using EmployeeEntity = CP.Repository.Models.Employee;

namespace CP.Shared.Employee
{
    public class EmployeeModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmployeeRetrievingService>().To<EmployeeRetrievingService>().InRequestScope();
            kernel.Bind<IEmployeeModifyingService, ISimpleModifyingService<EmployeeModel>>()
                .To<EmployeeModifyingService>()
                .InRequestScope();
            kernel.Bind<IEmployeeSerice>().To<EmployeeSerice>().InRequestScope();

            kernel.Bind<IEntityMapper<EmployeeEntity, EmployeeView>,
                    IEntityModifyingMapper<EmployeeModel, EmployeeEntity>>()
                .To<EmployeeMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            EmployeeMapper.Register(config);
        }
    }
}