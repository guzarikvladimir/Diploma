using System.Web.Optimization;

namespace WebApi
{
    public class BundleConfig
    {
        public static void RegisterBoundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Resources/vendor/jquery/jquery-3.2.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout")
                .Include("~/Resources/Scripts/Knockout/knockout-{version}.js",
                    "~/Resources/Scripts/Helpers/dblclick-helper.js",
                    "~/Resources/Scripts/Helpers/request.js",
                    "~/Resources/Scripts/Helpers/alert.js",
                    "~/Resources/Scripts/Helpers/guid.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Resources/Content/Common/controls.css",
                    "~/Resources/vendor/bootstrap/css/bootstrap.min.css",
                    "~/Resources/Content/Common/alert.css",
                    "~/Resources/Content/Common/loading.css",
                    "~/Resources/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                    "~/Resources/Content/Common/nav.css",
                    "~/Resources/Content/w3.css"));

            bundles.Add(new StyleBundle("~/Content/css/start")
                .Include("~/Resources/Content/Start/start-fonts.css",
                    "~/Resources/Content/Start/start.css"));

            bundles.Add(new StyleBundle("~/Content/css/table")
                .Include("~/Resources/vendor/animate/animate.css",
                    "~/Resources/vendor/select2/select2.min.css",
                    "~/Resources/vendor/perfect-scrollbar/perfect-scrollbar.css",
                    "~/Resources/Content/Common/util.css",
                    "~/Resources/Content/Compensation/compensation-table.css",
                    "~/Resources/Content/Common/table-filters.css"));

            bundles.Add(new ScriptBundle("~/bundles/compensation-table")
                .Include("~/Resources/vendor/bootstrap/js/popper.js",
                    "~/Resources/vendor/select2/select2.min.js",
                    "~/Resources/Scripts/Compensation/compensation-table.js"));

            bundles.Add(new ScriptBundle("~/bundles/compensation-table-data")
                .Include("~/Resources/Scripts/Compensation/Data/common.js",
                    "~/Resources/Scripts/Compensation/Data/table.js",
                    "~/Resources/Scripts/Compensation/Data/table.filters.js",
                    "~/Resources/Scripts/Compensation/Data/side.panel.js",
                    "~/Resources/Scripts/Compensation/Data/side.panel.list.js",
                    "~/Resources/Scripts/Compensation/Data/side.panel.form.js",
                    "~/Resources/Scripts/Compensation/Data/side.panel.header.js"));

            bundles.Add(new StyleBundle("~/Content/css/side")
                .Include("~/Resources/Content/Compensation/side-panel.css",
                    "~/Resources/Content/Compensation/side-panel-list.css",
                    "~/Resources/Content/Compensation/side-panel-form.css",
                    "~/Resources/Content/Compensation/side-panel-header.css"));

            bundles.Add(new ScriptBundle("~/bundles/import")
                .Include("~/Resources/Scripts/Import/import.js"));

            bundles.Add(new StyleBundle("~/Content/css/importExport")
                .Include("~/Resources/Content/ImportExport/importExport.css"));
        }
    }
}