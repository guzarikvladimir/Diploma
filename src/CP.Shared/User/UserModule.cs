using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.User.Models;
using CP.Shared.Contract.User.Services;
using CP.Shared.User.Mappers;
using CP.Shared.User.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.Shared.User
{
    public class UserModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUserRetrievingService>().To<UserRetrievingService>().InRequestScope();
            kernel.Bind<IEntityMapper<Repository.Models.User, UserView>>().To<UserMapper>().InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            UserMapper.Register(config);
        }
    }
}