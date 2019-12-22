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
        private readonly IContentLoader _contentLoader;
        private readonly IPageRouteHelper _pageRouteHelper;

        public NavigationService(IContentLoader contentLoader, IPageRouteHelper pageRouteHelper)
        {
            _contentLoader = contentLoader;
            _pageRouteHelper = pageRouteHelper;
        }

        public List<MenuItem> GetPrimaryNavigation()
        {
            var startPage = _contentLoader.Get<PageData>(SiteDefinition.Current.StartPage);

            List<MenuItem> primaryNavigation = new List<MenuItem>
            {
                new MenuItem
                {
                    Page = startPage,
                    Selected = _pageRouteHelper.Page.ContentLink.CompareToIgnoreWorkID(startPage.ContentLink)                    
                }
            };

            primaryNavigation.AddRange(GetChildItems(startPage.ContentLink));

            return primaryNavigation;
        }

        public List<MenuItem> GetChildItems(ContentReference rootLink)
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
                    Children = GetChildItems(page.ContentLink)
                }
                )
                .ToList();

            return menuItems;
        }
    }
}