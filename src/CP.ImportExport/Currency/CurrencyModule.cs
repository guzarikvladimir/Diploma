using CP.ImportExport.Currency.Contract;
using CP.ImportExport.Currency.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.Currency
{
    public class CurrencyModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICurrencyImportExportService>().To<CurrencyImportExportService>().InRequestScope();
        }
    }
}