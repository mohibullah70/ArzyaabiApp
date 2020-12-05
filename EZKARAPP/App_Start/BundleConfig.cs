using System.Web;
using System.Web.Optimization;

namespace EZKARAPP
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

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/bootstrap.bundle.js",
                      //"~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-4-navbar.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/select2.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/sweetalert.js",
                      "~/Scripts/bootstrap4-toggle.js",
                      "~/Scripts/site.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/css/bootstrap-4-navbar.css",
                      "~/Content/css/select2.css",
                      "~/Content/css/select2-bootstrap4.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/bootstrap-datepicker3.css",
                      "~/Content/sweetalert.css",
                      "~/Content/bootstrap4-toggle.css",
                      "~/Content/open-iconic-bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/highchartsjs").Include(
                      "~/Scripts/Highcharts/highcharts.js",
                      "~/Scripts/Highcharts/modules/exporting.js",
                      "~/Scripts/Highcharts/modules/offline-exporting.js",
                      "~/Scripts/site-highchart.js",
                      "~/Scripts/Highcharts/themes/grid-light.js"
                      ));


            bundles.Add(new StyleBundle("~/bundles/datatablecss").Include(
                      "~/Content/DataTables-1.10.20/css/dataTables.bootstrap4.css"));

            bundles.Add(new ScriptBundle("~/bundles/datatablejs").Include(
                      "~/Scripts/datatables.js",
                      "~/Scripts/site-datatable.js"
                      ));

        }
    }
}