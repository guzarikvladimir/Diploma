using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Contract.EmployeeRole.Models;
using CP.Shared.Contract.Role.Services;
using Ninject;
using EmployeeRoleEntity = CP.Repository.Models.EmployeeRole;

namespace CP.Shared.EmployeeRole.Mappers
{
    public class EmployeeRoleMapper : 
        IEntityMapper<EmployeeRoleEntity, EmployeeRoleView>,
        IEntityModifyingMapper<EmployeeRoleModel, EmployeeRoleEntity>
    {
        #region Injects

        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        [Inject]
        IRoleRetrievingService RoleRetrievingService { get; set; }

        #endregion

        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<EmployeeRoleEntity, EmployeeRoleView>();
            config.CreateMap<EmployeeRoleModel, EmployeeRoleEntity>();
        }

        public EmployeeRoleView Map(EmployeeRoleEntity model)
        {
            EmployeeRoleView result = Mapper.Map<EmployeeRoleView>(model);
            result.Employee = EmployeeRetrievingService.GetById(model.EmployeeId);
            result.Role = RoleRetrievingService.GetById(model.RoleId);

            return result;
        }

        public void Map(EmployeeRoleModel viewModel, EmployeeRoleEntity entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public EmployeeRoleEntity Map(EmployeeRoleModel viewModel)
        {
            return Mapper.Map<EmployeeRoleEntity>(viewModel);
        }
    }
}