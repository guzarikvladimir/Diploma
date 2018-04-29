using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.EmployeeStatus.Services;
using CP.Shared.Contract.JobFunction.Services;
using CP.Shared.Contract.Location.Services;
using Ninject;

namespace CP.Shared.Employee.Mappers
{
    public class EmployeeMapper : IEntityMapper<Repository.Models.Employee, EmployeeView>
    {
        #region Injects

        [Inject]
        IEmployeeStatusRetrievingService EmployeeStatusRetrievingService { get; set; }

        [Inject]
        ILocationRetrievingService LocationRetrievingService { get; set; }

        [Inject]
        IJobFunctionRetrievingService JobFunctionRetrievingService { get; set; }

        #endregion

        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<Repository.Models.Employee, EmployeeView>();
        }

        public EmployeeView Map(Repository.Models.Employee model)
        {
            EmployeeView view =  Mapper.Map<EmployeeView>(model);
            view.EmployeeStatus = EmployeeStatusRetrievingService.GetById(model.StatusId);
            view.Location = LocationRetrievingService.GetById(model.LocationId);
            view.JobFunctionView = JobFunctionRetrievingService.GetById(model.JobFunctionId);

            return view;
        }
    }
}