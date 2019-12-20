using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Filters;
using EPiServer.Framework.Cache;
using EPiServer.Logging;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using Feature.Robots.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feature.Robots.Repositories
{
    public class RobotsRepository : IRobotsRepository
    {
        const string RobotsSettingsPageCacheKey = "Feature.Robots.RepositoriesRobotsRepository.RobotsSettingsPage";

        private readonly IContentLoader _contentLoader;
        private readonly IContentTypeRepository _contentTypeRepository;
        private readonly IPageCriteriaQueryService _pageCriteriaQueryService;
        private readonly ILogger _logger = LogManager.GetLogger(typeof(RobotsRepository));

        public RobotsRepository(IContentLoader contentLoader, IContentTypeRepository contentTypeRepository, IPageCriteriaQueryService pageCriteriaQueryService)
        {
            _contentLoader = contentLoader;
            _contentTypeRepository = contentTypeRepository;
            _pageCriteriaQueryService = pageCriteriaQueryService;
        }

        public bool ShouldCancelRobotsPageCreation(int newContentTypeID)
        {
            if(newContentTypeID == _contentTypeRepository.Load(typeof(RobotsSettingsPage).Name).ID)
            {
                var robotsPages = GetRobotsSettingsPages();
                if (robotsPages?.Length > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void ClearRobotsCache(int newContentTypeID)
        {
            if(newContentTypeID == _contentTypeRepository.Load(typeof(RobotsSettingsPage).Name).ID)
            {
                CacheManager.Remove(RobotsSettingsPageCacheKey);
            }
        }

        public IHasRobots GetRobots()
        {
            if (!(CacheManager.Get(RobotsSettingsPageCacheKey) is IHasRobots robotsPage))
            {
                robotsPage = null;

                // First check if the start page implements IHasRobots

                var startPage = _contentLoader.Get<PageData>(SiteDefinition.Current.StartPage);

                if (startPage is IHasRobots)
                {
                    robotsPage = startPage as IHasRobots;
                }
                else
                {
                    // If the StartPage doesn't implement IHasRobots, try to find an instances of RobotsSettingsPage

                    var robotsSettingsPages = GetRobotsSettingsPages();
                    if (robotsSettingsPages != null)
                    {
                        robotsPage = robotsSettingsPages[0];
                    }
                }

                if (robotsPage == null)
                {
                    robotsPage = GetDefaultRobots();
                    _logger.Error("Could not find Robots Settings Page. Either update SiteDefinition.Current.StartPage to implement IHasRobots or create an instance of RobotsSettingsPage");
                }

                // Update the cache

                CacheManager.Insert(RobotsSettingsPageCacheKey, robotsPage);
            }

            return robotsPage;
        }

        public static IHasRobots GetDefaultRobots()
        {
            var robotsSettingsPage = new RobotsSettingsPage
            {
                Robots = new Models.Blocks.RobotsBlock { }
            };

            return robotsSettingsPage;
        }

        public IHasRobots[] GetRobotsSettingsPages()
        {
            PropertyCriteriaCollection criterias = new PropertyCriteriaCollection();

            PropertyCriteria criteria = new PropertyCriteria();
            criteria.Condition = CompareCondition.Equal;
            criteria.Name = "PageTypeID"; // This is an Episerver constant
            criteria.Type = PropertyDataType.PageType;
            criteria.Value = _contentTypeRepository.Load(typeof(RobotsSettingsPage).Name).ID.ToString();
            criteria.Required = true;

            criterias.Add(criteria);

            var pageResults = _pageCriteriaQueryService
                .FindPagesWithCriteria(PageReference.RootPage, criterias)
                .Where(pr => !pr.IsDeleted)
                .ToList();

            if (pageResults.Count() == 0)
            {
                return null;
            }
            else
            {
                if (pageResults.Count() > 1)
                {
                    _logger.Warning($"Multiple RobotsSettingsPage pages found ({ pageResults.Count() })."
                        + string.Join("", pageResults.Select(pr => $"({ pr.Name }, { pr.ContentGuid })")));
                }

                return pageResults
                    .Select(pr => pr as IHasRobots)
                    .ToArray();
            }
        }
    }
}