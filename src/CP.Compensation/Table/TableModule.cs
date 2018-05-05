using CP.Compensation.Table.Contract;
using CP.Compensation.Table.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.Compensation.Table
{
    public class TableModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICompensationTableSerivce>().To<CompensationTableSerivce>().InRequestScope();
        }
    }
}