using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Core.Services;
using CP.Shared.Contract.JobFunction.Models;
using CP.Shared.Contract.JobFunction.Services;
using CP.Shared.JobFunction.Mappers;
using CP.Shared.JobFunction.Services;
using Ninject;
using Ninject.Web.Common;
using JobFunctionEntity = CP.Repository.Models.JobFunction;

namespace CP.Shared.JobFunction
{
    public class JobFunctionModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IJobFunctionRetrievingService>().To<JobFunctionRetrievingService>().InRequestScope();
            kernel.Bind<IJobFunctionModifyingService, ISimpleModifyingService<JobFunctionModel>>()
                .To<JobFunctionModifyingService>()
                .InRequestScope();

            kernel.Bind<IEntityMapper<JobFunctionEntity, JobFunctionView>, 
                    IEntityModifyingMapper<JobFunctionModel, JobFunctionEntity>>()
                .To<JobFunctionMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            JobFunctionMapper.Register(config);
        }
    }
}