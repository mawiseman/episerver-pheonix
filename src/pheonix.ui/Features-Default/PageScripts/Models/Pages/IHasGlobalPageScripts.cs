using Features.PageScripts.Models.Blocks;

namespace Features.PageScripts.Models.Pages
{
    public interface IHasGlobalPageScripts
    {
        PageScriptsBlock GlobalPageScripts { get; set; }
    }
}