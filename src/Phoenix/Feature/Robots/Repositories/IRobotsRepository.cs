using Feature.Robots.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feature.Robots.Repositories
{
    public interface IRobotsRepository
    {
        bool ShouldCancelRobotsPageCreation(int newContentTypeID);

        void ClearRobotsCache(int newContentTypeID);

        IHasRobots GetRobots();

        IHasRobots[] GetRobotsSettingsPages();
    }
}