using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Features.ContentIcons;
using Features.ContentIcons.Business.DataAnnotations;
using Features.ImageUrlGenerator.Business.DataAnnotations;
using Features.PageScripts.Models.Blocks;
using Features.PageScripts.Models.Pages;
using System.ComponentModel.DataAnnotations;

namespace pheonix.ui.Models.Pages
{
    [ContentType(DisplayName = "Start Page",
        GUID = "ab45a186-d58f-4549-9289-49fd98116f11",
        Description = "")]
    [AvailableContentTypes(Include = new[] { typeof(StandardPage) })]
    [ContentIcon(ContentIcon.ObjectStart)]
    [ImageUrlGenerator("Start Page")]
    public class StartPage : BasePage, IHasGlobalPageScripts
    {
        [Display(Name = "Global Page Scripts", 
            GroupName = "Global Page Scripts", 
            Order = 600, 
            Description = "These scripts will be rendered on every page in the site")]
        virtual public PageScriptsBlock GlobalPageScripts { get; set; }
    }
}