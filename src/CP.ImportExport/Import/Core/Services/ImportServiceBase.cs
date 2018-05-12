using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using CP.ImportExport.Import.Core.Contract;
using CP.ImportExport.Import.Core.Models;
using CP.Platform.Db.Contract;
using CP.Shared.Contract.Core.Models;
using CP.Shared.Contract.Core.Services;
using Ninject;
using OfficeOpenXml;

namespace CP.ImportExport.Import.Core.Services
{
    public abstract class ImportServiceBase<TImportModel, TEntityModel> : IImportServiceBase
        where TImportModel : new()
        where TEntityModel : class, IModelWithId<Guid?>
    {
        #region Injects

        [Inject]
        protected ISimpleModifyingService<TEntityModel> SimpleModifyingService { get; set; }

        [Inject]
        protected IDbContextScopeFactory DbContextScopeFactory { get; set; }

        #endregion

        private string contentType => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public void Upload(HttpPostedFileBase file)
        {
            var models = new List<TImportModel>();
            using (var package = new ExcelPackage(file.InputStream))
            {
                var currentSheet = package.Workbook.Worksheets;
                var workSheet = currentSheet.First();
                var endCol = workSheet.Dimension.End.Column;
                var endRow = workSheet.Dimension.End.Row;

                for (int row = 2; row <= endRow; row++)
                {
                    var model = new TImportModel();
                    for (int col = 1; col <= endCol; col++)
                    {
                        string propName = workSheet.Cells[1, col].Value.ToString();
                        string propValue = workSheet.Cells[row, col].Value.ToString();
                        PropertyInfo prop = model.GetType().GetProperty(propName, BindingFlags.Instance
                                                                                  | BindingFlags.Public);
                        if (prop != null)
                        {
                            prop.SetValue(model, propValue);
                        }
                    }

                    models.Add(model);
                }
            }

            List<TEntityModel> parsedModels = Parse(models).ToList();
            AddOrUpdateWrapper(parsedModels);
        }

        public TemplateModel GenerateTemplate()
        {
            byte[] result;
            using (ExcelPackage package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                var properties = typeof(TImportModel).GetProperties(BindingFlags.Instance | BindingFlags.Public);
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
                ContentType = contentType,
                Name = $"{GetTemplateName()}_{DateTime.Now}.xlsx"
            };
        }

        public abstract string GetTemplateName();

        public abstract IEnumerable<TEntityModel> Parse(List<TImportModel> importModels);

        private void AddOrUpdateWrapper(List<TEntityModel> models)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                AddOrUpdate(models);

                scope.SaveChanges();
            }
        }

        public abstract void AddOrUpdate(List<TEntityModel> models);
    }
}