using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Core.Services;
using CP.Shared.Contract.JobFunctionTitile.Models;
using CP.Shared.Contract.JobFunctionTitile.Services;
using CP.Shared.JobFunctionTitle.Mappers;
using CP.Shared.JobFunctionTitle.Services;
using Ninject;
using Ninject.Web.Common;
using JobFunctionTitleEntity = CP.Repository.Models.JobFunctionTitle;

namespace CP.Shared.JobFunctionTitle
{
    public class JobFunctionTitleModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IJobFunctionTitleRetrievingService>().To<JobFunctionTitleRetrievingService>().InRequestScope();
            kernel.Bind<IJobFunctionTitleModifyingService, ISimpleModifyingService<JobFunctionTitleModel>>()
                .To<JobFunctionTitleModifyingService>()
                .InRequestScope();

            kernel.Bind<IEntityMapper<JobFunctionTitleEntity, JobFunctionTitleView>,
                    IEntityModifyingMapper<JobFunctionTitleModel, JobFunctionTitleEntity>>()
                .To<JobFunctionTitleMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            JobFunctionTitleMapper.Register(config);
        }
    }
}