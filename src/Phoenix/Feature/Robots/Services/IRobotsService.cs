using Feature.Robots.Models.Pages;

namespace Feature.Robots.Services
{
    public interface IRobotsService
    {
        bool ShouldCancelRobotsSettingsPageCreation(int newContentTypeID);

        void ClearRobotsCache(int currentContentTypeID);

        IHasRobots GetRobots(bool ignoreCache);

        IHasRobots[] GetRobotsSettingsPages();
    }
}