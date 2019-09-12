using Phoenix.Models.Pages;

namespace Phoenix.Models.ViewModels
{
    // "out" is required so that we can pass a PageViewModel<StartPage> into a view
    // but declare it's layout to expect an IPageViewModel<SitePageData>
    // (only an interface can use the out declaration)
    public interface IPageViewModel<out T> where T : SitePageData
    {
        T CurrentPage { get; }
        StartPage HomePage { get; }
    }
}