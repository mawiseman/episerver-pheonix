using Feature.PageScripts.Models.Blocks;

namespace Feature.PageScripts.Models.Pages
{
    public interface IHasPageScripts
    {
        PageScriptsBlock PageScripts { get; set; }
    }
}