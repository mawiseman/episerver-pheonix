using EPiServer.Core;
using EPiServer.DataAnnotations;
using Features.ImageUrlGenerator.Business.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Features.RichText.Models.Blocks
{
    [ContentType(
        DisplayName = "Rich Text",
        GUID = "D9C6C7C2-9536-4D51-8A02-B448A29A64B1")]
    [ImageUrlGenerator("Rich Text")]
    public class RichTextBlock : BlockData
    {
        [CultureSpecific]
        [Display(Name = "Content", Order = 100)]
        public virtual XhtmlString Content { get; set; }
    }
}
