using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Features.ImageUrlGenerator.Business.DataAnnotations;

namespace pheonix.ui.Models.Pages
{
    [ContentType(DisplayName = "Standard Page", 
        GUID = "249ea8ea-bc61-4287-a5d4-6ec97dd3ee71", 
        Description = "")]
    [ImageUrlGenerator("Standard Page")]
    public class StandardPage : BasePage
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