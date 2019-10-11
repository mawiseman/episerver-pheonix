using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Foundation.Media.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Media.Pages
{
    /// <summary>
    /// This page can be use to test all the avaliable Media types in this feature.
    /// </summary>
    [ContentType(DisplayName = "Media Test Page",
        GUID = "6C3FF9F9-4948-4B25-B9F1-9F7C92CD41D4")]
    public class MediaTestPage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Image File",
            Order = 2)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference ImageFile { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Video File",
            Order = 3)]
        [UIHint(UIHint.Video)]
        public virtual ContentReference VideoFile { get; set; }

    }
}