using System;
using Castle.Core.Internal;

namespace CP.ImportExport.Common.Helpers
{
    public static class ImportExportHelper
    {
        public static string ContentType => "applicatoni/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public static Guid? ParseId(string value)
        {
            return !value.IsNullOrEmpty() ? Guid.Parse(value) : (Guid?) null;
        }
    }
}