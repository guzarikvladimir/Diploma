using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.User.Models;
using UserEntity = CP.Repository.Models.User;

namespace CP.Shared.User.Mappers
{
    public class UserMapper : 
        IEntityMapper<UserEntity, UserView>,
        IEntityModifyingMapper<UserModel, UserEntity>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<UserEntity, UserView>();
            config.CreateMap<UserModel, UserEntity>();
        }

        public UserView Map(UserEntity model)
        {
            return Mapper.Map<UserView>(model);
        }

        public void Map(UserModel model, UserEntity entityModel)
        {
            Mapper.Map(model, entityModel);
        }

        public UserEntity Map(UserModel viewModel)
        {
            return Mapper.Map<UserEntity>(viewModel);
        }
    }
}