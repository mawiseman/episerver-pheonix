using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Filters;
using EPiServer.Logging;
using EPiServer.Web;
using Feature.PageScripts.Models.Blocks;
using Feature.PageScripts.Models.Pages;
using System.Linq;

namespace Feature.PageScripts.Services
{
    public class PageScriptService : IPageScriptService
    {
        private const string GlobalPageScriptsCacheKey = "Feature.PageScripts.Models.Services";

        private readonly IContentLoader _contentLoader;
        private readonly IContentTypeRepository _contentTypeRepository;
        private readonly IPageCriteriaQueryService _pageCriteriaQueryService;
        private readonly ILogger _logger = LogManager.GetLogger(typeof(PageScriptService));

        public PageScriptService(IContentLoader contentLoader, IContentTypeRepository contentTypeRepository, IPageCriteriaQueryService pageCriteriaQueryService)
        {
            _contentLoader = contentLoader;
            _contentTypeRepository = contentTypeRepository;
            _pageCriteriaQueryService = pageCriteriaQueryService;
        }

        public bool ShouldCancelGlobalPageScriptPageCreation(int newContentTypeID)
        {
            if (newContentTypeID == _contentTypeRepository.Load(typeof(PageScriptsSettingsPage).Name).ID)
            {
                var robotsPages = GetGlobalPageScriptsSettingsPages();
                if (robotsPages?.Length > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void ClearRobotsCache(int currentContentTypeID)
        {
            if (currentContentTypeID == _contentTypeRepository.Load(typeof(PageScriptsSettingsPage).Name).ID)
            {
                CacheManager.Remove(GlobalPageScriptsCacheKey);
            }
        }

        public IHasGlobalPageScripts GetGlobalPageScripts(bool ignoreCache)
        {
            // Don't run scripts in edit mode

            if (EPiServer.Editor.PageEditing.PageIsInEditMode)
            {
                return GetDefaultGlobalPageScripts();
            }

            // Get the page from cache

            if (ignoreCache || !(CacheManager.Get(GlobalPageScriptsCacheKey) is IHasGlobalPageScripts globalPageScriptsPage))
            {
                globalPageScriptsPage = null;

                // Check if the start page has Global Page Scripts

                var startPage = _contentLoader.Get<PageData>(SiteDefinition.Current.StartPage);

                if (startPage is IHasGlobalPageScripts)
                {
                    globalPageScriptsPage = startPage as IHasGlobalPageScripts;
                }
                else
                {
                    // If the StartPage doesn't implement IHasGlobalPageScripts, try to find an instances of PageScriptsSettingsPage

                    var globalPageScriptsPages = GetGlobalPageScriptsSettingsPages();
                    if (globalPageScriptsPages != null)
                    {
                        globalPageScriptsPage = globalPageScriptsPages[0];
                    }
                }

                if (globalPageScriptsPage == null)
                {
                    globalPageScriptsPage = GetDefaultGlobalPageScripts();
                    _logger.Error("Could not find Global Page Scripts Settings Page. Either update SiteDefinition.Current.StartPage to implement IHasRobots or create an instance of RobotsSettingsPage");
                }

                // Update the cache

                CacheManager.Insert(GlobalPageScriptsCacheKey, globalPageScriptsPage);
            }

            return globalPageScriptsPage;
        }

        public IHasGlobalPageScripts GetDefaultGlobalPageScripts()
        {
            var globapPageScriptsPage = new PageScriptsSettingsPage
            {
                GlobalPageScripts = new PageScriptsBlock()
            };

            return globapPageScriptsPage;
        }

        public IHasGlobalPageScripts[] GetGlobalPageScriptsSettingsPages()
        {
            PropertyCriteriaCollection criterias = new PropertyCriteriaCollection();

            PropertyCriteria criteria = new PropertyCriteria
            {
                Condition = CompareCondition.Equal,
                Name = "PageTypeID", // This is an Episerver constant
                Type = PropertyDataType.PageType,
                Value = _contentTypeRepository.Load(typeof(PageScriptsSettingsPage).Name).ID.ToString(),
                Required = true
            };

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
                    _logger.Warning($"Multiple GlobalPageScriptsSettingsPage pages found ({ pageResults.Count() })."
                        + string.Join("", pageResults.Select(pr => $"({ pr.Name }, { pr.ContentGuid })")));
                }

                return pageResults
                    .Select(pr => pr as IHasGlobalPageScripts)
                    .ToArray();
            }
        }
    }
}