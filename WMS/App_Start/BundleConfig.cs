using System.Web;
using System.Web.Optimization;

namespace WMS.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Configurando os arquivos de CSS
            bundles.Add(new StyleBundle("~/Content/bootstrap/css").Include(
                      "~/Content/bootstrap/css/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Content/dist/css").Include(
                      "~/Content/dist/css/font-awesome.min.css",
                      "~/Content/dist/css/ionicons.min.css",
                      "~/Content/dist/css/Site.min.css"));
            bundles.Add(new StyleBundle("~/Content/dist/css/skins").Include(
                                  "~/Content/dist/css/skins/_all-skins.min.css"));
            bundles.Add(new StyleBundle("~/Content/plugins/iCheck/flat").Include(
                               "~/Content/plugins/iCheck/flat/blue.css"));
            bundles.Add(new StyleBundle("~/Content/plugins/morris").Include(
                               "~/Content/plugins/morris/morris.css"));
            bundles.Add(new StyleBundle("~/Content/plugins/jvectormap").Include(
                               "~/Content/plugins/jvectormap/jquery-jvectormap-1.2.2.css"));
            bundles.Add(new StyleBundle("~/Content/plugins/datepicker").Include(
                               "~/Content/plugins/datepicker/datepicker3.css",
                               "~/Content/plugins/datepicker/daterangepicker-bs3.css"));
            bundles.Add(new StyleBundle("~/Content/plugins/bootstrap-wysihtml5").Include(
                               "~/Content/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"));
            bundles.Add(new StyleBundle("~/Content/plugins/JQueryValidate").Include(
                              "~/Content/plugins/JQueryValidate/jquery.validate.bootstrap.css"));

            // Configurando os arquivos de JS
            bundles.Add(new ScriptBundle("~/Content/plugins/jQuery").Include(
                "~/Content/plugins/jQuery/jQuery-2.1.4.min.js"));
            bundles.Add(new ScriptBundle("~/Content/bootstrap/js").Include(
                "~/Content/bootstrap/js/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/Content/dist/js").Include(
                "~/Content/dist/js/wms-min.js",
                "~/Content/dist/js/moment.min.js",
                "~/Content/dist/js/app.min.js",
                "~/Content/dist/js/demo.js"));
            bundles.Add(new ScriptBundle("~/Content/plugins/morris").Include(
                "~/Content/plugins/morris/morris.min.js"));
            bundles.Add(new ScriptBundle("~/Content/plugins/sparkline").Include(
                "~/Content/plugins/sparkline/jquery.sparkline.min.js"));
            bundles.Add(new ScriptBundle("~/Content/plugins/jvectormap").Include(
                "~/Content/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                "~/Content/plugins/jvectormap/jquery-jvectormap-world-mill-en.js"));
            bundles.Add(new ScriptBundle("~/Content/plugins/knob").Include(
                "~/Content/plugins/knob/jquery.knob.js"));
            bundles.Add(new ScriptBundle("~/Content/plugins/daterangepicker").Include(
                "~/Content/plugins/daterangepicker/daterangepicker.js"));
            bundles.Add(new ScriptBundle("~/Content/plugins/bootstrap-wysihtml5").Include(
                    "~/Content/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"));
            bundles.Add(new ScriptBundle("~/Content/plugins/slimScroll").Include(
                    "~/Content/plugins/slimScroll/jquery.slimscroll.min.js"));
            bundles.Add(new ScriptBundle("~/Content/plugins/fastclick").Include(
                    "~/Content/plugins/fastclick/fastclick.min.js"));
            bundles.Add(new ScriptBundle("~/Content/dist/js/pages").Include(
                    "~/Content/dist/js/pages/dashboard.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/Scripts").Include(
                        "~/Scripts/WMSUtil.js"));

            /*
            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
            */
        }
    }
}