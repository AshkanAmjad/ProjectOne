using System.Web;
using System.Web.Optimization;

namespace CMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            bundles.Add(new StyleBundle("~/Content/KendoUI").Include(
                            "~/Content/Kendo/kendo.common.css",
                            "~/Content/Kendo/kendo.rtl.css",
                            "~/Content/Kendo/kendo.silver.css",
                            "~/Content/kendo/kendo.bootstrap.css"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/KendoUI").Include(
                "~/Scripts/kendoUI/Jszip.js",
                "~/Scripts/kendoUI/kendo.web.js",
                "~/Scripts/kendoUI/kendo.aspnetmvc.js",
                "~/Scripts/kendoUI/cultures/kendo.culture.fa.js",
                "~/Scripts/kendoUI/cultures/kendo.fa-ir.js"
            ));
        }
    }
}
