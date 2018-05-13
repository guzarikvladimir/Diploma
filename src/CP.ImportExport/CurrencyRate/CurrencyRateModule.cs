using CP.ImportExport.CurrencyRate.Contract;
using CP.ImportExport.CurrencyRate.Service;
using CP.Platform.DependencyResolvers.Services;
using Ninject;
using Ninject.Web.Common;

namespace CP.ImportExport.CurrencyRate
{
    public class CurrencyRateModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICurrencyRateImportExportService>().To<CurrencyRateImportExportService>().InRequestScope();
        }
    }
}