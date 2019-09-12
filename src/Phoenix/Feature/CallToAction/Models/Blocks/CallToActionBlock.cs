using EPiServer;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Foundation.ContentIcons.Business.DataAnnotations;
using Foundation.ImageUrlGenerator.Business.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Feature.CallToAction.Models.Blocks
{
    [ContentType(
        DisplayName = "Call to Action",
        GUID = "8838cc86-f8f9-4b7e-9599-82db2cc211eb")]
    [ImageUrlGenerator("Call to Action")]
    [ContentIcon(Foundation.ContentIcons.ContentIcon.Bell)]
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
