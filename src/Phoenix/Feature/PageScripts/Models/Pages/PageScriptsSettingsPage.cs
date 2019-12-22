using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using Feature.PageScripts.Models.Blocks;
using Foundation.ContentIcons;
using Foundation.ContentIcons.Business.DataAnnotations;
using Foundation.ImageUrlGenerator.Business.DataAnnotations;

namespace Feature.PageScripts.Models.Pages
{
    [ContentType(DisplayName = "Page Scripts Settings",
        GUID = "6922c353-6267-48a3-a9cd-9e8931fff81f",
        Description = "")]
    [AvailableContentTypes(Availability = Availability.None)]
    [ContentIcon(ContentIcon.ObjectUnknown)]
    [ImageUrlGenerator("Page Scripts Settings")]
    public class PageScriptsSettingsPage : PageData, IHasGlobalPageScripts
    {
        [Display(
            Name = "Global Page Scripts",
            Description = "The scripts in this sections will be displayed on every page",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual PageScriptsBlock GlobalPageScripts { get; set; }
    }
}