using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Employee.Mappers;
using CP.Shared.Employee.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.Shared.Employee
{
    public class EmployeeModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmployeeRetrievingService>().To<EmployeeRetrievingService>().InRequestScope();
            kernel.Bind<IEmployeeSerice>().To<EmployeeSerice>().InRequestScope();

            kernel.Bind<IEntityMapper<Repository.Models.Employee, EmployeeView>>()
                .To<EmployeeMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            EmployeeMapper.Register(config);
        }
    }
}