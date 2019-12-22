using Feature.Robots.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feature.Robots.Repositories
{
    public interface IRobotsService
    {
        bool ShouldCancelRobotsSettingsPageCreation(int newContentTypeID);

        void ClearRobotsCache(int currentContentTypeID);

        IHasRobots GetRobots(bool ignoreCache);

        IHasRobots[] GetRobotsSettingsPages();
    }
}