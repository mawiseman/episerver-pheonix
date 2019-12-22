using Feature.PageScripts.Models.Pages;

namespace Feature.PageScripts.Services
{
    public interface IPageScriptService
    {
        bool ShouldCancelGlobalPageScriptPageCreation(int newContentTypeID);

        void ClearRobotsCache(int currentContentTypeID);

        IHasGlobalPageScripts GetGlobalPageScripts(bool ignoreCache);

        IHasGlobalPageScripts GetDefaultGlobalPageScripts();

        IHasGlobalPageScripts[] GetGlobalPageScriptsSettingsPages();
    }
}