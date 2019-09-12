using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using Phoenix.Models.Pages;

namespace Phoenix.Models.ViewModels
{  
    public class PageViewModel<T> : IPageViewModel<T> where T : SitePageData
    {
        public T CurrentPage { get; protected set; }

        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }

        // a read-only property will not appear in All Properties view
        // because it is not stored in the database.
        public StartPage HomePage
        {
            get
            {
                var loader = ServiceLocator.Current.GetInstance<IContentLoader>();
                if (!ContentReference.IsNullOrEmpty(ContentReference.StartPage))
                {
                    return loader.Get<StartPage>(ContentReference.StartPage);
                }
                return null;
            }
        }
    }
}