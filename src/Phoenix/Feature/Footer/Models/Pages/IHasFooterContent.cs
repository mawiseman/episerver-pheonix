using Feature.Footer.Models.Blocks;

namespace Feature.Footer.Models.Pages
{
    public interface IHasFooterContent
    {
        FooterBlock FooterContent { get; set; }
    }
}