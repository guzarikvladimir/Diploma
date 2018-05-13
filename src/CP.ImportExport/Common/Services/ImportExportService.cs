using System;
using System.Linq;
using System.Web.Mvc;
using CP.ImportExport.Common.Contract;
using CP.ImportExport.Common.Models;
using CP.Platform.Helpers;

namespace CP.ImportExport.Common.Services
{
    public class ImportExportService : IImportExportService
    {
        public SelectList GetOptions()
        {
            var enumData = from ImportExportOption e in Enum.GetValues(typeof(ImportExportOption))
                select new
                {
                    Id = (int)e,
                    Name = e.GetDisplayValue()
                };

            return new SelectList(enumData, "Id", "Name");
        }
    }
}