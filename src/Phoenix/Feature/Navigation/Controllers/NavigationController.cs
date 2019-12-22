using EPiServer.Web.Mvc;
using Feature.Navigation.Services;
using System.Web.Mvc;

namespace Feature.Navigation.Controllers
{
    public class NavigationController : Controller
    {
        private readonly INavigationService _navigationService;

        public NavigationController(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult PrimaryNavigation(bool? ignoreCache = false)
        {
            var viewModel = _navigationService.GetPrimaryNavigation(ignoreCache.Value);

            return PartialView("~/Feature/Navigation/Views/Navigation/PrimaryNavigation.cshtml", viewModel);
        }
    }
}