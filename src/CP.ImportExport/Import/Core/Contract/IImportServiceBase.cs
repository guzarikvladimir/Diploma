using System.Web;

namespace CP.ImportExport.Import.Core.Contract
{
    public interface IImportServiceBase
    {
        void Upload(HttpPostedFileBase file);
    }
}