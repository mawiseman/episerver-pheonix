using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pheonix.Business.Site
{
    [GroupDefinitions]
    public static class SiteTabNames
    {
        [Display(Order = 20)]
        public const string SEO = "SEO";

        [Display(Order = 20)]
        public const string PageScripts = "Page Scripts";
    }
}