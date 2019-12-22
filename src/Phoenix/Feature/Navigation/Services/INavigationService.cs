using EPiServer.Core;
using Feature.Navigation.Models;
using System.Collections.Generic;

namespace Feature.Navigation.Services
{
    public interface INavigationService
    {
        List<MenuItem> GetPrimaryNavigation();
        List<MenuItem> GetChildItems(ContentReference rootLink);
    }
}