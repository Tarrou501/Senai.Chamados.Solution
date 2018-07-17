using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Senai.Chamados.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/DataTables/css").Include(
                "~/Content/DataTables/media/css/dataTables.bootstrap.min.css",
                "~/Content/DataTables/media/css/jquery.dataTables.min.css",
                "~/Content/DataTables/extensions/Buttons/css/buttons.dataTables.min.css",
                "~/Content/DataTables/extensions/Buttons/css/buttons.bootstrap.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/DataTables/js").Include(
                "~/Scripts/DataTables/media/js/jquery.dataTables.min.js",
                "~/Scripts/DataTables/media/js/dataTables.bootstrap.min.js",
                "~/Scripts/DataTables/extensions/Buttons/js/dataTables.buttons.min.js",
                "~/Scripts/DataTables/extensions/Buttons/js/buttons.html5.min.js",
                "~/Scripts/DataTables/extensions/Buttons/js/buttons.print.min.js",
                "~/Scripts/jszip.min.js",
                "~/Scripts/pdfmake/pdfmake.min.js",
                "~/Scripts/pdfmake/vfs_fonts.js"
                ));
        }
    }
}