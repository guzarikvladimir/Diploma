using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using CP.ImportExport.Import.Core.Contract;
using CP.Platform.Db.Contract;
using CP.Shared.Contract.Core.Models;
using CP.Shared.Contract.Core.Services;
using Ninject;
using OfficeOpenXml;

namespace CP.ImportExport.Import.Core.Services
{
    public abstract class ImportServiceBase<TImportModel, TEntityModel> : IImportServiceBase
        where TImportModel: new() 
        where TEntityModel : class, IModelWithId<Guid?>
    {
        #region Injects

        [Inject]
        protected ISimpleModifyingService<TEntityModel> SimpleModifyingService { get; set; }

        [Inject]
        protected IDbFactory DbFactory { get; set; }

        #endregion

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

        public abstract IEnumerable<TEntityModel> Parse(List<TImportModel> importModels);

        private void AddOrUpdateWrapper(List<TEntityModel> models)
        {
            using (var scope = DbFactory.Create())
            {
                AddOrUpdate(models);

                scope.SaveChanges();
            }
        }

        public abstract void AddOrUpdate(List<TEntityModel> models);
    }
}