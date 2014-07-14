using System.Web.Optimization;
using FlatFinder.MvcClient.App_Start;

namespace FlatFinder.MvcClient
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/lib/jquery-{version}.js"));

            // 3rd Party JavaScript files
            bundles.Add(new ScriptBundle("~/bundles/jsextlibs")
                //.IncludeDirectory("~/Scripts/lib", "*.js", searchSubdirectories: false));
                .Include(
                    // jQuery plugins
                    "~/Scripts/lib/activity-indicator.js",
                    "~/Scripts/lib/jquery.mockjson.js",
                    "~/Scripts/lib/TrafficCop.js",
                    "~/Scripts/lib/infuser.js", // depends on TrafficCop

                    // Knockout and its plugins
                    "~/Scripts/lib/knockout-{version}.js",
                    "~/Scripts/lib/knockout.activity.js",
                    "~/Scripts/lib/knockout.asyncCommand.js",
                    "~/Scripts/lib/knockout.dirtyFlag.js",
                    "~/Scripts/lib/knockout.validation.js",
                    "~/Scripts/lib/koExternalTemplateEngine.js",

                    // Other 3rd party libraries
                    //"~/Scripts/lib/underscore.js",
                    "~/Scripts/lib/moment.js",
                    "~/Scripts/lib/sammy-{version}.js",
                    "~/Scripts/lib/amplify/amplify.*",
                    "~/Scripts/lib/toastr.js"
                    ));

            // All application JS files (except mocks)
            bundles.Add(new ScriptBundle("~/bundles/jsapplibs")
                .IncludeDirectory("~/Scripts/app/", "*.js", searchSubdirectories: false));

            // 3rd Party CSS files
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/boilerplate-styles.css",
                "~/Content/toastr.css"));

            // Custom LESS files
            bundles.Add(new Bundle("~/Content/Less", new LessTransform(), new CssMinify())
                .Include("~/Content/styles.less")
                .Include("~/Content/toastr.less"));
        }
    }
}