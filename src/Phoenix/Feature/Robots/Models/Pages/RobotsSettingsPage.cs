using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using Feature.Robots.Models.Blocks;
using Foundation.ContentIcons;
using Foundation.ContentIcons.Business.DataAnnotations;
using Foundation.ImageUrlGenerator.Business.DataAnnotations;

namespace Feature.Robots.Models.Pages
{
    [ContentType(DisplayName = "RobotsSettingsPage", 
        GUID = "110d598e-3b8c-4bf7-89fa-076f69d8b19f", 
        Description = "")]
    [AvailableContentTypes(Availability = Availability.None)]
    [ContentIcon(ContentIcon.ObjectUnknown)]
    [ImageUrlGenerator("Robots Settings")]
    public class RobotsSettingsPage : PageData, IHasRobots
    {
        [Display(
            Name = "Robots Settings",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual RobotsBlock Robots { get; set; }
    }
}