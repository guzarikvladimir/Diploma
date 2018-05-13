using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using CP.ImportExport.Common.Contract;
using CP.ImportExport.Common.Helpers;
using CP.ImportExport.Common.Models;
using CP.Platform.Crud.Contract;
using CP.Platform.Crud.Models;
using CP.Platform.Db.Contract;
using Ninject;
using OfficeOpenXml;

namespace CP.ImportExport.Common.Services
{
    public abstract class ImportExportServiceBase<TImportExportModel, TEntityModel, TEntityView> : 
        IImportExportServiceBase
        where TImportExportModel : new()
        where TEntityModel : class, IEntityModel<Guid?>
        where TEntityView : class
    {
        #region Injects

        [Inject]
        protected ISimpleRetrievingService<TEntityView> SimpleRetrievingService { get; set; }

        [Inject]
        protected ISimpleModifyingService<TEntityModel> SimpleModifyingService { get; set; }

        [Inject]
        protected IDbContextScopeFactory DbContextScopeFactory { get; set; }

        #endregion

        public void Upload(HttpPostedFileBase file)
        {
            var models = new List<TImportExportModel>();
            using (var package = new ExcelPackage(file.InputStream))
            {
                var currentSheet = package.Workbook.Worksheets;
                var workSheet = currentSheet.First();
                var endCol = workSheet.Dimension.End.Column;
                var endRow = workSheet.Dimension.End.Row;

                for (int row = 2; row <= endRow; row++)
                {
                    var model = new TImportExportModel();
                    for (int col = 1; col <= endCol; col++)
                    {
                        string propName = workSheet.Cells[1, col].Value.ToString();
                        string propValue = workSheet.Cells[row, col].Value?.ToString();
                        PropertyInfo prop = model.GetType().GetProperty(propName, BindingFlags.Instance
                                                                                  | BindingFlags.Public);
                        if (prop != null && propValue != null)
                        {
                            prop.SetValue(model, propValue);
                        }
                    }

                    models.Add(model);
                }
            }

            AddOrUpdateWrapper(models);
        }

        public TemplateModel GenerateTemplate()
        {
            byte[] result;
            using (ExcelPackage package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add(GetTemplateName());

                var properties = typeof(TImportExportModel).GetProperties(BindingFlags.Instance | BindingFlags.Public);
                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = properties[i].Name;
                    worksheet.Column(i + 1).AutoFit(12);
                }

                result = package.GetAsByteArray();
            }

            return new TemplateModel()
            {
                Content = result,
                ContentType = ImportExportHelper.ContentType,
                Name = $"{GetTemplateName()}_{DateTime.Now}.xlsx"
            };
        }

        public TemplateModel Export()
        {
            byte[] result;
            IEnumerable<TImportExportModel> models = GetExportModels();
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(GetTemplateName());
                PropertyInfo[] properties = typeof(TImportExportModel).GetProperties(BindingFlags.Instance
                                                                               | BindingFlags.Public);
                SetHeader(worksheet, properties);
                int row = 2;
                foreach (TImportExportModel model in models)
                {
                    for (int col = 1; col <= properties.Length; col++)
                    {
                        worksheet.Cells[row, col].Value = properties[col - 1].GetValue(model, null);
                        worksheet.Column(col).AutoFit(12);
                    }

                    row++;
                }

                result = package.GetAsByteArray();
            }

            return new TemplateModel()
            {
                Content = result,
                ContentType = ImportExportHelper.ContentType,
                Name = $"Exported_{GetTemplateName()}_{DateTime.Now}.xlsx"
            };
        }

        private void SetHeader(ExcelWorksheet worksheet, PropertyInfo[] properties)
        {
            for (int col = 1; col <= properties.Length; col++)
            {
                worksheet.Cells[1, col].Value = properties[col - 1].Name;
                worksheet.Column(col + 1).AutoFit(12);
            }
        }

        public abstract string GetTemplateName();

        public abstract IEnumerable<TEntityModel> Parse(List<TImportExportModel> importModels);

        private void AddOrUpdateWrapper(List<TImportExportModel> models)
        {
            List<TEntityModel> parsedModels = Parse(models).ToList();
            using (var scope = DbContextScopeFactory.Create())
            {
                foreach (TEntityModel model in parsedModels)
                {
                    SimpleModifyingService.AddOrUpdate(model);
                }

                scope.SaveChanges();
            }
        }

        public abstract IEnumerable<TImportExportModel> GetExportModels();
    }
}