using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Web;
using EPiServer.Web.Routing;
using Feature.Navigation.Models;
using System.Collections.Generic;
using System.Linq;

namespace Feature.Navigation.Services
{
    public class NavigationService : INavigationService
    {
        const string PrimaryNavigationCacheKey = "Feature.Navigation.Services.NavigationService.PrimaryNavigationCacheKey";

        private readonly IContentLoader _contentLoader;
        private readonly IPageRouteHelper _pageRouteHelper;

        public NavigationService(IContentLoader contentLoader, IPageRouteHelper pageRouteHelper)
        {
            _contentLoader = contentLoader;
            _pageRouteHelper = pageRouteHelper;
        }

        public void ClearNavigationCache()
        {
            CacheManager.Remove(PrimaryNavigationCacheKey);
        }

        public List<MenuItem> GetPrimaryNavigation(bool ignoreCache)
        {
            if (ignoreCache || !(CacheManager.Get(PrimaryNavigationCacheKey) is List<MenuItem> primaryNavigation))
            {
                var startPage = _contentLoader.Get<PageData>(SiteDefinition.Current.StartPage);

                primaryNavigation = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Page = startPage,
                        Selected = _pageRouteHelper.Page.ContentLink.CompareToIgnoreWorkID(startPage.ContentLink)
                    }
                };

                primaryNavigation.AddRange(GetPrimaryNavigationChildItems(startPage.ContentLink));

                // Update the cache

                CacheManager.Insert(PrimaryNavigationCacheKey, primaryNavigation);
            }

            return primaryNavigation;
        }

        public List<MenuItem> GetPrimaryNavigationChildItems(ContentReference rootLink)
        {
            var currentContentLink = _pageRouteHelper.Page.ContentLink;

            var filterForVisitor = new FilterContentForVisitor();

            var pagePath = _contentLoader.GetAncestors(currentContentLink)
                .Reverse()
                .Select(x => x.ContentLink)
                .SkipWhile(x => !x.CompareToIgnoreWorkID(rootLink))
                .ToList();

            var menuItems = _contentLoader.GetChildren<PageData>(rootLink)
                .Where(page => !filterForVisitor.ShouldFilter(page) && page.VisibleInMenu)
                .Select(page => new MenuItem
                {
                    Page = page,
                    Selected = page.ContentLink.CompareToIgnoreWorkID(currentContentLink)
                            || pagePath.Contains(page.ContentLink),
                    Children = GetPrimaryNavigationChildItems(page.ContentLink)
                }
                )
                .ToList();

            return menuItems;
        }
    }
}