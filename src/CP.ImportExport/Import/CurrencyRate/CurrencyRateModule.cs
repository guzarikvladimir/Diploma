using CP.ImportExport.Import.CurrencyRate.Contract;
using CP.ImportExport.Import.CurrencyRate.Service;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.Import.CurrencyRate
{
    public class CurrencyRateModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICurrencyRateImportService>().To<CurrencyRateImportService>().InRequestScope();
        }
    }
}