using System.Web.Mvc;

namespace CP.ImportExport.Common.Contract
{
    public interface IImportExportService
    {
        SelectList GetOptions();
    }
}