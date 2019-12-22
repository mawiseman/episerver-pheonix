using EPiServer.Core;
using Feature.Navigation.Models;
using System.Collections.Generic;

namespace Feature.Navigation.Services
{
    public interface INavigationService
    {
        void ClearNavigationCache();
        List<MenuItem> GetPrimaryNavigation(bool ignoreCache);
        List<MenuItem> GetPrimaryNavigationChildItems(ContentReference rootLink);
    }
}