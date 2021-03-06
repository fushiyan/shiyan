﻿using System.Web;
using System.Web.Optimization;

namespace shiyan
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*",
                        "~/js/jquery.js",
                        "~/js/jquery-ui.js",
                        "~/js/slimscroll.js",
                        "~/js/jquery.flot.js",
                        "~/js/jquery.flot.resize.js",
                        "~/js/jquery.flot.pie.resize.js", 
                        "~/js/jquery.flot.pie.resize.js" 
                        ));
            bundles.Add(new ScriptBundle("~/bundles/slider").Include(
                "~/js/jquery.bxslider.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
