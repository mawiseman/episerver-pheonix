using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Features.ViewFolders.Business
{
    public class ViewFolderRazorViewEngine : RazorViewEngine
    {
        /*  
         *      Placeholders:
         *      {2} - Name of the area
         *      {1} - Name of the controller
         *      {0} - Name of the action (name of the partial view)
        */
        private static readonly string[] AdditionalPartialViewFormats =
        {
            "~/Views/{0}/Partials/Index.cshtml",
            "~/Views/Shared/PagePartials/{0}.cshtml",
            "~/Views/Shared/Partials/{0}.cshtml",
            "~/Views/Shared/Blocks/{0}.cshtml",
        };

        public ViewFolderRazorViewEngine()
        {
            this.PartialViewLocationFormats = this.PartialViewLocationFormats.Union(AdditionalPartialViewFormats).ToArray();
        }
    }
}