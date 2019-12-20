using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Feature.Robots.Models.Pages;
using Foundation.ContentIcons;
using Foundation.ContentIcons.Business.DataAnnotations;
using Foundation.ImageUrlGenerator.Business.DataAnnotations;

namespace Phoenix.Models.Pages
{
    [ContentType(DisplayName = "SettingsPage", 
        GUID = "d838aac8-6500-4454-a25b-976966270c11", 
        Description = "")]
    [ImageUrlGenerator("Site Settings")]
    [ContentIcon(ContentIcon.Settings)]
    [AvailableContentTypes(Include = new[] { typeof(RobotsSettingsPage) })]
    public class SettingsPage : PageData
    {
        
    }
}