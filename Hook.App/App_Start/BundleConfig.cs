using System.Web;
using System.Web.Optimization;

namespace Hook
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Force optimization to be on or off, regardless of web.config setting
            //BundleTable.EnableOptimizations = false;
            bundles.UseCdn = false;

            // .debug.js, -vsdoc.js and .intellisense.js files 
            // are in BundleTable.Bundles.IgnoreList by default.
            // Clear out the list and add back the ones we want to ignore.
            // Don't add back .debug.js.
            bundles.IgnoreList.Clear();
            bundles.IgnoreList.Ignore("*-vsdoc.js");
            bundles.IgnoreList.Ignore("*intellisense.js");

            // Modernizr goes separate since it loads first
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-{version}.js"));

            // jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery",
                "//code.jquery.com/jquery-1.9.1.min.js")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery.validate.min.js"));

            //jQuery Mobile
            bundles.Add(new ScriptBundle("~/bundles/jquerymobile")
                .Include("~/Scripts/jquery.mobile-{version}.js"));

            // jQuery Mobile 1.4
            //bundles.Add(new ScriptBundle("~/bundles/jquerymobile", "code.jquery.com/mobile/1.4.0-alpha.1/jquery.mobile-1.4.0-alpha.1.js"));



            // 3rd Party JavaScript files
            bundles.Add(new ScriptBundle("~/bundles/jsextlibs")
                //.IncludeDirectory("~/Scripts", "*.js", searchSubdirectories: false));
                .Include(

                    // Knockout and its plugins
                    "~/Scripts/knockout-{version}.js",
                    "~/Scripts/knockout.mapping-latest.js",
                // Twitter Bootstrap
                    //"~/Scripts/bootstrap.js",
                // Other 3rd party libraries
                    "~/Scripts/moment.js",
                    //"~/Scripts/sammy-{version}.js",
                    "~/Scripts/amplify.min.*"
                    //,"~/Scripts/toastr.js"
                    ));

            // All application JS files
            bundles.Add(new ScriptBundle("~/bundles/app_js")
                .IncludeDirectory("~/App_JS/", "*.js", searchSubdirectories: false));

            //3rd Party CSS files
            bundles.Add(new StyleBundle("~/Content/css")
                .IncludeDirectory("~/Content/", "*.css", searchSubdirectories: false));

            //JQuer Mobile 1.4
            //bundles.Add(new StyleBundle("~/Content","code.jquery.com/mobile/1.4.0-alpha.1/jquery.mobile-1.4.0-alpha.1.css"));

            //bundles.Add(new StyleBundle("~/Content/app_css")
            //    .IncludeDirectory("~/Content/app_css/", "app.css", searchSubdirectories: false));


            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //    "~/Content/boilerplate-styles.css",
            //    "~/Content/toastr.css",
            //    "~/Content/toastr-responsive.css"));

            // Custom LESS files
            //bundles.Add(new Bundle("~/Content/Less", new LessTransform(), new CssMinify())
            //    .Include("~/Content/styles.less"));
        }
    }
}