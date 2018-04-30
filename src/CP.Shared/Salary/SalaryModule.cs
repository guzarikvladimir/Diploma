using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using CP.Shared.Contract.Salary.Services;
using CP.Shared.Salary.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.Shared.Salary
{
    public class SalaryModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISalaryPromotionRetrievingService>().To<SalaryPromotionRetrievingService>().InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            //SalaryPromotionMapper.Register(config);
        }
    }
}