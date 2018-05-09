using CP.ImportExport.Import.Currency.Contract;
using CP.ImportExport.Import.Currency.Services;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.Import.Currency
{
    public class CurrencyModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICurrencyImportService>().To<CurrencyImportService>().InRequestScope();
        }
    }
}