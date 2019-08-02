using EPiServer;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Features.ContentIcons.Business.DataAnnotations;
using Features.ImageUrlGenerator.Business.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Features.CallToAction.Models.Blocks
{
    [ContentType(
        DisplayName = "Call to Action",
        GUID = "3E1F7F51-D601-4203-B059-25599FA08FC1")]
    [ImageUrlGenerator("Call to Action")]
    public class CallToActionBlock : BlockData
    {
        [CultureSpecific]
        [Display(Name = "Title", Order = 100)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Display(Name = "Blurb", Order = 200)]
        [UIHint(UIHint.Textarea)]
        public virtual string Blurb { get; set; }

        [CultureSpecific]
        [Display(Name = "Button Text", Order = 300)]
        public virtual string ButtonText { get; set; }

        [CultureSpecific]
        [Display(Name = "Button Link", Order = 400)]
        public virtual Url ButtonLink { get; set; }

        [CultureSpecific]
        [Display(Name = "Background Image", Order = 500)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference BackgroundImage { get; set; }

        [CultureSpecific]
        [Display(Name = "Foreground Image", Order = 500)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference ForegroundImage { get; set; }
    }
}
