using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Admin.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-3.3.1.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/bootbox.js",
                "~/Scripts/Custom.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Content/bootstrap.min.css",
                "~/fontawesome-free-5.3.1-web/css/all.css",
                "~/Content/css/Style.css"
                ));
        }
    }
}