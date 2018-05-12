using System.Web;
using CP.ImportExport.Import.Core.Models;

namespace CP.ImportExport.Import.Core.Contract
{
    public interface IImportServiceBase
    {
        void Upload(HttpPostedFileBase file);

        TemplateModel GenerateTemplate();
    }
}