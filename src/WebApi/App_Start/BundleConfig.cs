using System.Web.Optimization;

namespace WebApi
{
    public class BundleConfig
    {
        public static void RegisterBoundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/JQuery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout")
                .Include("~/Scripts/Knockout/knockout-{version}.js")
                .Include("~/Scripts/Helpers/dblclick-helper.js")
                .Include("~/Scripts/Helpers/request-helper.js")
                .Include("~/Scripts/Helpers/alert-helper.js")
                .Include("~/Scripts/Helpers/guid-helper.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/compensation")
                .Include("~/Scripts/Compensation/compensation.js")
                .Include("~/Scripts/Compensation/compensation-side-panel.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/Bootstrap/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/Core/alert.css"));

            bundles.Add(new StyleBundle("~/Content/compensation/css")
                .Include("~/Content/Compensation/compensation.css"));
        }
    }
}