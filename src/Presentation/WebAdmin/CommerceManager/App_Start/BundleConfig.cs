using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtoCommerce.Web.CommerceManager
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js", "~/Scripts/angular-resource.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/ng-grid-{version}.js",
                        "~/Content/App/app.js",
                        "~/Content/App/Services/*.js",
                        "~/Content/App/Directives/*.js", "~/Content/App/Services/*.js", "~/Content/App/Controllers/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                        "~/Scripts/toastr.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css", "~/Content/ng-grid.css"));

            //bundles.Add(new StyleBundle("~/Content/angular").Include("~/Scripts/App/Directives/Content/*.css"));
            bundles.Add(new StyleBundle("~/Content/toastr").Include("~/Content/toastr.css"));
        }
    }
}