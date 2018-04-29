using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.User.Models;
using CP.Shared.Contract.User.Services;
using CP.Shared.User.Mappers;
using CP.Shared.User.Services;
using Ninject;
using Ninject.Web.Common;
using UserEntity = CP.Repository.Models.User;

namespace CP.Shared.User
{
    public class UserModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUserRetrievingService>().To<UserRetrievingService>().InRequestScope();
            kernel.Bind<IUserModifyingService>().To<UserModifyingService>().InRequestScope();

            kernel.Bind<IEntityMapper<UserEntity, UserView>>().To<UserMapper>().InRequestScope();
            kernel.Bind<IEntityModifyingMapper<UserModel, UserEntity>>().To<UserMapper>().InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            UserMapper.Register(config);
        }
    }
}