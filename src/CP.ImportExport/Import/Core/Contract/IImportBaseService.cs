using System.Web;

namespace CP.ImportExport.Import.Core.Contract
{
    public interface IImportBaseService
    {
        void Upload(HttpPostedFileBase file);
    }
}