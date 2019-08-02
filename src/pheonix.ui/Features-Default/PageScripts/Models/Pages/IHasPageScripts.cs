using Features.PageScripts.Models.Blocks;

namespace Features.PageScripts.Models.Pages
{
    public interface IHasPageScripts
    {
        PageScriptsBlock PageScripts { get; set; }
    }
}