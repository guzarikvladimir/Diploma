﻿using AutoMapper;
using CP.Platform.Crud.Contract;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.EmployeeStatus.Models;
using CP.Shared.Contract.EmployeeStatus.Services;
using CP.Shared.EmployeeStatus.Mappers;
using CP.Shared.EmployeeStatus.Services;
using Ninject;
using Ninject.Web.Common;
using EmployeeStatusEntity = CP.Repository.Models.EmployeeStatus;

namespace CP.Shared.EmployeeStatus
{
    public class EmployeeStatusModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmployeeStatusRetrievingService, ISimpleRetrievingService<EmployeeStatusView>>()
                .To<EmployeeStatusRetrievingService>()
                .InRequestScope();
            kernel.Bind<IEmployeeStatusModifyingService, ISimpleModifyingService<EmployeeStatusModel>>()
                .To<EmployeeStatusModifyingService>()
                .InRequestScope();

            kernel.Bind<IEntityMapper<EmployeeStatusEntity, EmployeeStatusView>,
                    IEntityModifyingMapper<EmployeeStatusModel, EmployeeStatusEntity>>()
                .To<EmployeeStatusMapper>()
                .InRequestScope();
        }


        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            EmployeeStatusMapper.Register(config);
        }
    }
}