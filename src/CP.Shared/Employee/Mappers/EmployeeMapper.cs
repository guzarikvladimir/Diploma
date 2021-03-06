﻿using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.EmployeeStatus.Services;
using CP.Shared.Contract.JobFunction.Services;
using CP.Shared.Contract.Location.Services;
using Ninject;
using EmployeeEntity = CP.Repository.Models.Employee;

namespace CP.Shared.Employee.Mappers
{
    public class EmployeeMapper : 
        IEntityMapper<EmployeeEntity, EmployeeView>,
        IEntityModifyingMapper<EmployeeModel, EmployeeEntity>
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
            config.CreateMap<EmployeeEntity, EmployeeView>()
                .ForMember(dst => dst.EmployeeStatus, cfg => cfg.Ignore())
                .ForMember(dst => dst.Location, cfg => cfg.Ignore())
                .ForMember(dst => dst.JobFunction, cfg => cfg.Ignore());
            config.CreateMap<EmployeeModel, EmployeeEntity>();
        }

        public EmployeeView Map(EmployeeEntity model)
        {
            EmployeeView view =  Mapper.Map<EmployeeView>(model);
            view.EmployeeStatus = EmployeeStatusRetrievingService.GetById(model.StatusId);
            view.Location = LocationRetrievingService.GetById(model.LocationId);
            view.JobFunction = JobFunctionRetrievingService.GetById(model.JobFunctionId);

            return view;
        }

        public void Map(EmployeeModel viewModel, EmployeeEntity entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public EmployeeEntity Map(EmployeeModel viewModel)
        {
            return Mapper.Map<EmployeeEntity>(viewModel);
        }
    }
}