using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Foundation.ContentIcons;
using Foundation.ContentIcons.Business.DataAnnotations;
using Foundation.ImageUrlGenerator.Business.DataAnnotations;
using Phoenix.Business.Site;
using System.ComponentModel.DataAnnotations;
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
    public class StartPage : SitePageData, IHasFooterContent
    {
        [Display(Name = "Footer Content",
            GroupName = SiteTabNames.SiteSettings,
            Order = 800,
            Description = "Footer Content")]
        virtual public FooterBlock FooterContent { get; set; }
    }
}