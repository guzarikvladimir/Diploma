using System.Web;
using CP.ImportExport.Import.Core.Models;

namespace CP.ImportExport.Import.Core.Contract
{
    public interface IImportResolverService
    {
        void Resolve(ImportOption importOption, HttpPostedFileBase file);
    }
}