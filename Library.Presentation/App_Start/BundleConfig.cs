using System.Web;
using System.Web.Optimization;

namespace Library.Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/library").Include(
                    "~/Scripts/forms/jquery.maskedinput.min.js",
                    "~/Scripts/library.js"
                ));
            
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-hover-dropdown.min.js",
                      "~/Scripts/jquery.blockui.min.js",
                      "~/Scripts/jquery.sparkline.min.js",
                      "~/Scripts/jquery.slimscroll.min.js",
                      "~/Scripts/jquery.uniform.min.js",
                      "~/Scripts/jquery-migrate.min.js",
                      "~/Scripts/jquery.cokie.min.js",
                      "~/Content/global/bootstrap-datepicker/js/bootstrap-datepicker.js",
                      "~/Content/global/select2/select2.min.js",
                      "~/Content/global/bootstrap-datepicker/js/locales/bootstrap-datepicker.pt-BR.js",
                      "~/Content/global/bootstrap-toastr/toastr.min.js",
                      "~/Scripts/ui-toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/morris").Include(
                     "~/Scripts/morris.min.js",
                     "~/Scripts/raphael-min.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/tema3").Include(
                     "~/Scripts/metronic.js",
                     "~/Scripts/tasks.js",
                     "~/Scripts/layout3/layout.js",
                     "~/Scripts/specifc/SystemPages.js"

                     ));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                      "~/Content/global/datatables/media/js/jquery.dataTables.min.js",
                      "~/Content/global/datatables/plugins/bootstrap/dataTables.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatablegenerico").Include(
                      "~/Scripts/table-advanced.js"));

            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                    "~/Scripts/forms/jquery.maskedinput.min.js",
                    "~/Scripts/Login.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/profile").Include(
                    "~/Scripts/specific/profile.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/formwizard").Include(
                    "~/content/global/bootstrap-wizard/jquery.bootstrap.wizard.min.js"
                    , "~/content/global/jquery-validation/js/jquery.validate.min.js"
                    , "~/content/global/jquery-validation/js/additional-methods.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/icheck").Include(
                    "~/content/global/icheck/icheck.min.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/icheckcss").Include(
                    "~/Content/global/icheck/skins/all.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/bundles/global").Include(
                      "~/Content/global/font-awesome/css/font-awesome.min.css",
                      "~/Content/global/simple-line-icons/simple-line-icons.min.css",
                      "~/Content/global/uniform/css/uniform.default.min.css",
                      "~/Content/global/bootstrap-datepicker/css/datepicker.css",
                      "~/Content/global/select2/select2.css",
                      "~/Content/global/datatables/plugins/bootstrap/dataTables.bootstrap.css",
                      "~/Content/global/bootstrap-toastr/toastr.css"));

            bundles.Add(new StyleBundle("~/bundles/temas").Include(
                      "~/Content/temas/plugins.css",
                      "~/Content/global/components.css",
                       "~/Content/temas/layout.css",
                       "~/Content/temas/default.css",
                      "~/Content/temas/blue-steel.css"));

            bundles.Add(new StyleBundle("~/bundles/tema3").Include(
                     "~/Content/temas/3/components-rounded.css",
                     "~/Content/temas/3/plugins.css",
                     "~/Content/temas/3/layout.css",
                     "~/Content/temas/3/blue-steel.css",
                     "~/Content/temas/3/custom.css",
                     "~/Content/plugins/custom-theme.css"
                     ));
        }
    }    
}
