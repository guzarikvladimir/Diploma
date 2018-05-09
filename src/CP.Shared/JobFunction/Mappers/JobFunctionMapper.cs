using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.JobFunction.Models;
using CP.Shared.Contract.JobFunctionPosition.Services;
using CP.Shared.Contract.JobFunctionTitile.Services;
using Ninject;
using JobFunctionEntity = CP.Repository.Models.JobFunction;

namespace CP.Shared.JobFunction.Mappers
{
    public class JobFunctionMapper : 
        IEntityMapper<JobFunctionEntity, JobFunctionView>,
        IEntityModifyingMapper<JobFunctionModel, JobFunctionEntity>
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
                .ForMember(dst => dst.Position, cfg => cfg.Ignore())
                .ForMember(dst => dst.Title, cfg => cfg.Ignore());
            config.CreateMap<JobFunctionModel, JobFunctionEntity>();
        }

        public JobFunctionView Map(JobFunctionEntity model)
        {
            JobFunctionView view = Mapper.Map<JobFunctionView>(model);
            view.Position = JobFunctionPositionRetrievingService.GetById(model.PositionId);
            view.Title = JobFunctionTitleRetrievingService.GetById(model.TitleId);

            return view;
        }

        public void Map(JobFunctionModel viewModel, JobFunctionEntity entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public JobFunctionEntity Map(JobFunctionModel viewModel)
        {
            return Mapper.Map<JobFunctionEntity>(viewModel);
        }
    }
}