using System;
using System.Web;
using CP.ImportExport.Import.Core.Contract;
using CP.ImportExport.Import.Core.Models;
using CP.ImportExport.Import.Currency.Contract;
using Ninject;

namespace CP.ImportExport.Import.Core.Services
{
    public class ImportResolverService : IImportResolverService
    {
        #region Injects

        [Inject]
        ICurrencyImportService CurrencyImportService { get; set; }

        #endregion

        public void Resolve(ImportOption importOption, HttpPostedFileBase file)
        {
            switch (importOption)
            {
                case ImportOption.Currency:
                    CurrencyImportService.Upload(file);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}