using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feature.PageScripts
{
    public static class Constants
    {
        /// <summary>
        /// Using constants here because the Project references them. If this feature changes... the project shouldn't have to
        /// </summary>
        public static class ViewPaths
        {
            public const string GlobalPageHeadScripts = "~/Feature/PageScripts/Views/Blocks/_GlobalPageHeadScript.cshtml";
            public const string GlobalPageBodyStartScripts = "~/Feature/PageScripts/Views/Blocks/_GlobalPageBodyStartScript.cshtml";
            public const string GlobalPageBodyEndScripts = "~/Feature/PageScripts/Views/Blocks/_GlobalPageBodyEndScript.cshtml";

            public const string PageHeadScripts = "~/Feature/PageScripts/Views/Blocks/_PageHeadScript.cshtml";
            public const string PageBodyStartScripts = "~/Feature/PageScripts/Views/Blocks/_PageBodyStartScript.cshtml";
            public const string PageBodyEndScripts = "~/Feature/PageScripts/Views/Blocks/_PageBodyEndScript.cshtml";
        }
    }
}