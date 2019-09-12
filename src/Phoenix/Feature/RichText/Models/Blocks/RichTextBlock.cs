using EPiServer.Core;
using EPiServer.DataAnnotations;
using Foundation.ContentIcons.Business.DataAnnotations;
using Foundation.ImageUrlGenerator.Business.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Feature.RichText.Models.Blocks
{
    [ContentType(
        DisplayName = "Rich Text",
        GUID = "372233cb-0346-458c-9a7c-b73d4cd7f7dc")]
    [ImageUrlGenerator("Rich Text")]
    [ContentIcon(Foundation.ContentIcons.ContentIcon.Pen)]
    public class RichTextBlock : BlockData
    {
        [CultureSpecific]
        [Display(Name = "Content", Order = 100)]
        public virtual XhtmlString Content { get; set; }
    }
}
