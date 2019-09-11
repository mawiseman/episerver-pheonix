using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Features.PageScripts
{
    public static class Constants
    {
        /// <summary>
        /// Using constants here because the Project references them. If this feature changes... the project shouldn't have to
        /// </summary>
        public static class ViewPaths
        {
            public const string GlobalPageHeadScripts = "~/Features-Default/PageScripts/Views/Blocks/_GlobalPageHeadScript.cshtml";
            public const string GlobalPageBodyStartScripts = "~/Features-Default/PageScripts/Views/Blocks/_GlobalPageBodyStartScript.cshtml";
            public const string GlobalPageBodyEndScripts = "~/Features-Default/PageScripts/Views/Blocks/_GlobalPageBodyEndScript.cshtml";

            public const string PageHeadScripts = "~/Features-Default/PageScripts/Views/Blocks/_PageHeadScript.cshtml";
            public const string PageBodyStartScripts = "~/Features-Default/PageScripts/Views/Blocks/_PageBodyStartScript.cshtml";
            public const string PageBodyEndScripts = "~/Features-Default/PageScripts/Views/Blocks/_PageBodyEndScript.cshtml";
        }
    }
}