using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.JobFunction.Models;
using CP.Shared.Contract.JobFunctionPosition.Services;
using CP.Shared.Contract.JobFunctionTitile.Services;
using Ninject;
using JobFunctionEntity = CP.Repository.Models.JobFunction;

namespace CP.Shared.JobFunction.Mappers
{
    public class JobFunctionMapper : IEntityMapper<JobFunctionEntity, JobFunctionView>
    {
        #region Injects

        [Inject]
        IJobFunctionPositionRetrievingService JobFunctionPositionRetrievingService { get; set; }

        [Inject]
        IJobFunctionTitleRetrievingService JobFunctionTitleRetrievingService { get; set; }

        #endregion

        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<JobFunctionEntity, JobFunctionView>()
                .ForMember(dst => dst.JobFunctionPosition, cfg => cfg.Ignore())
                .ForMember(dst => dst.JobFunctionTitle, cfg => cfg.Ignore());
        }

        public JobFunctionView Map(JobFunctionEntity model)
        {
            JobFunctionView view = Mapper.Map<JobFunctionView>(model);
            view.JobFunctionPosition = JobFunctionPositionRetrievingService.GetById(model.PositionId);
            view.JobFunctionTitle = JobFunctionTitleRetrievingService.GetById(model.TitleId);

            return view;
        }
    }
}