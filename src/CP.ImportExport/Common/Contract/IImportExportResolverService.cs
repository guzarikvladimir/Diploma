using System.Web;
using CP.ImportExport.Common.Models;

namespace CP.ImportExport.Common.Contract
{
    public interface IImportExportResolverService
    {
        void ResolveImport(ImportExportOption importExportOption, HttpPostedFileBase file);

        TemplateModel ResolveExport(ImportExportOption exportOption);

        TemplateModel GenerateTemplate(ImportExportOption importExportOption);
    }
}