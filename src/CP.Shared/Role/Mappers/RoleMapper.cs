using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Role.Models;
using RoleEntity = CP.Repository.Models.Role;

namespace CP.Shared.Role.Mappers
{
    public class RoleMapper : 
        IEntityMapper<RoleEntity, RoleView>,
        IEntityModifyingMapper<RoleModel, RoleEntity>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<RoleEntity, RoleView>();
            config.CreateMap<RoleModel, RoleEntity>();
        }

        public RoleView Map(RoleEntity model)
        {
            return Mapper.Map<RoleView>(model);
        }

        public void Map(RoleModel viewModel, RoleEntity entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public RoleEntity Map(RoleModel viewModel)
        {
            return Mapper.Map<RoleEntity>(viewModel);
        }
    }
}