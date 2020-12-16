using EPiServer;
using EPiServer.Core;
using EPiServer.Globalization;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

public static class UrlHelpers
{
    /// <summary>
    /// Returns the target URL for a Url. Respects the page's shortcut setting
    /// so if the page is set as a shortcut to another page or an external URL that URL
    /// will be returned.
    /// </summary>
    public static IHtmlString PageLinkUrl(this UrlHelper urlHelper, Url url)
    {
        if (url == null)
        {
            return MvcHtmlString.Empty;
        }

        var urlBuilder = new UrlBuilder(url);
        Global.UrlRewriteProvider.ConvertToExternal(urlBuilder, null, Encoding.UTF8);

        return new MvcHtmlString(urlBuilder.Uri.IsAbsoluteUri ? urlBuilder.Uri.AbsoluteUri : urlBuilder.Uri.OriginalString);
    }

    /// <summary>
    /// Returns the target URL for a ContentReference. Respects the page's shortcut setting
    /// so if the page is set as a shortcut to another page or an external URL that URL
    /// will be returned.
    /// </summary>
    public static IHtmlString PageLinkUrl(this UrlHelper urlHelper, ContentReference contentLink)
    {
        if (ContentReference.IsNullOrEmpty(contentLink))
        {
            return MvcHtmlString.Empty;
        }

        var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
        var page = contentLoader.Get<PageData>(contentLink);
        
        return PageLinkUrl(urlHelper, page);
    }

    /// <summary>
    /// Returns the target URL for a page. Respects the page's shortcut setting
    /// so if the page is set as a shortcut to another page or an external URL that URL
    /// will be returned.
    /// </summary>
    public static IHtmlString PageLinkUrl(this UrlHelper urlHelper, PageData page)
    {
        var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
        switch (page.LinkType)
        {
            case PageShortcutType.Normal:
            case PageShortcutType.FetchData:
                return new MvcHtmlString(urlResolver.GetUrl(page.ContentLink));

            case PageShortcutType.Shortcut:
                var shortcutProperty = page.Property["PageShortcutLink"] as PropertyPageReference;
                if (shortcutProperty != null && !ContentReference.IsNullOrEmpty(shortcutProperty.ContentLink))
                {
                    return urlHelper.PageLinkUrl(shortcutProperty.ContentLink);
                }
                break;

            case PageShortcutType.External:
                return new MvcHtmlString(page.LinkURL);
        }
        return MvcHtmlString.Empty;
    }

    public static RouteValueDictionary GetPageRoute(this RequestContext requestContext, ContentReference contentLink)
    {
        var values = new RouteValueDictionary();
        values[RoutingConstants.NodeKey] = contentLink;
        values[RoutingConstants.LanguageKey] = ContentLanguage.PreferredCulture.Name;
        return values;
    }
}

