using Feature.PageScripts.Models.Blocks;

namespace Feature.PageScripts.Models.Pages
{
    public interface IHasGlobalPageScripts
    {
        PageScriptsBlock GlobalPageScripts { get; set; }
    }
}