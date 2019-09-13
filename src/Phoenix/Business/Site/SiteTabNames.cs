using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Phoenix.Business.Site
{
    /// <summary>
    /// I think this could be a foundational class for use that new projects just inherit
    /// </summary>
    [GroupDefinitions]
    public static class SiteTabNames
    {
        [Display(Order = 10)]
        public const string SEO = "SEO";

        [Display(Order = 15)]
        public const string PageScripts = "Page Scripts";

        [Display(Order = 20)]
        public const string SiteSettings = "Site Settings";
    }
}