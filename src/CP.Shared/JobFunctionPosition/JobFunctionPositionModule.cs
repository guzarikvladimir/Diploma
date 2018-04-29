using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.JobFunctionPosition.Models;
using CP.Shared.Contract.JobFunctionPosition.Services;
using CP.Shared.JobFunctionPosition.Mappers;
using CP.Shared.JobFunctionPosition.Services;
using Ninject;
using Ninject.Web.Common;
using JobFunctionPositionEntity = CP.Repository.Models.JobFunctionPosition;

namespace CP.Shared.JobFunctionPosition
{
    public class JobFunctionPositionModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IJobFunctionPositionRetrievingService>()
                .To<JobFunctionPositionRetrievingService>()
                .InRequestScope();

            kernel.Bind<IEntityMapper<JobFunctionPositionEntity, JobFunctionPositionView>>()
                .To<JobFunctionPositionMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            JobFunctionPositionMapper.Register(config);
        }
    }
}