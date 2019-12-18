using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Foundation.ContentIcons;
using Foundation.ContentIcons.Business.DataAnnotations;
using Foundation.ImageUrlGenerator.Business.DataAnnotations;
using Feature.PageScripts.Models.Blocks;
using Feature.PageScripts.Models.Pages;
using Phoenix.Business.Site;
using System.ComponentModel.DataAnnotations;
using Feature.Robots.Models.Blocks;
using Feature.Robots.Models.Pages;
using Feature.Footer.Models.Blocks;
using Feature.Footer.Models.Pages;

namespace Phoenix.Models.Pages
{
    [ContentType(DisplayName = "Start Page",
        GUID = "506d9dd1-a88d-48ba-9b16-e07104c98a4a",
        Description = "")]
    [AvailableContentTypes(Include = new[] { typeof(StandardPage) })]
    [ContentIcon(ContentIcon.ObjectStart)]
    [ImageUrlGenerator("Start Page")]
    public class StartPage : SitePageData, IHasGlobalPageScripts, IHasRobots, IHasFooterContent
    {
        [Display(Name = "Global Page Scripts", 
            GroupName = SiteTabNames.SiteSettings, 
            Order = 600, 
            Description = "These scripts will be rendered on every page in the site")]
        virtual public PageScriptsBlock GlobalPageScripts { get; set; }

        [Display(Name = "Robots.txt",
            GroupName = SiteTabNames.SiteSettings,
            Order = 700,
            Description = "Content for robots.txt")]
        virtual public RobotsBlock Robots { get; set; }

        [Display(Name = "Footer Content",
            GroupName = SiteTabNames.SiteSettings,
            Order = 800,
            Description = "Footer Content")]
        virtual public FooterBlock FooterContent { get; set; }
    }
}