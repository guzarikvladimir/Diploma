using System.Web;
using CP.ImportExport.Common.Models;

namespace CP.ImportExport.Common.Contract
{
    public interface IImportExportServiceBase
    {
        void Upload(HttpPostedFileBase file);

        TemplateModel Export();

        TemplateModel GenerateTemplate();
    }
}