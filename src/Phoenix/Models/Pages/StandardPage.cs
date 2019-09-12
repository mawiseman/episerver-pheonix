using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Foundation.ImageUrlGenerator.Business.DataAnnotations;

namespace Pheonix.Models.Pages
{
    [ContentType(DisplayName = "Standard Page", 
        GUID = "3fae62cd-3d17-4e54-9017-ff37fe4c0819", 
        Description = "")]
    [ImageUrlGenerator("Standard Page")]
    [AvailableContentTypes(Include = new[] { typeof(StandardPage) })]
    public class StandardPage : SitePageData
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Main body",
                    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual XhtmlString MainBody { get; set; }
         */
    }
}