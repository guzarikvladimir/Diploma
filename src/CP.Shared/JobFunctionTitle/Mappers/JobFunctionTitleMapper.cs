using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.JobFunctionTitile.Models;
using JobFunctionTitleEntity = CP.Repository.Models.JobFunctionTitle;

namespace CP.Shared.JobFunctionTitle.Mappers
{
    public class JobFunctionTitleMapper : IEntityMapper<JobFunctionTitleEntity, JobFunctionTitleView>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<JobFunctionTitleEntity, JobFunctionTitleView>();
        }

        public JobFunctionTitleView Map(JobFunctionTitleEntity model)
        {
            return Mapper.Map<JobFunctionTitleView>(model);
        }
    }
}