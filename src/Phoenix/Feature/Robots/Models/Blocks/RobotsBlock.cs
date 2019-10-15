using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace Feature.Robots.Models.Blocks
{
    [ContentType(
        DisplayName = "Robots",
        GUID = "D1A235F0-27EB-4E5F-8A69-AAAFA901B39B",
        Description = "Content for Robots.txt",
        AvailableInEditMode = false)]
    public class RobotsBlock : BlockData
    {
        [Display(Name = "Robots.txt", Order = 100)]
        [UIHint(UIHint.Textarea)]
        public virtual string Robots { get; set; }
    }
}