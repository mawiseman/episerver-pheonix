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
        public ActionResult PrimaryNavigation()
        {
            var viewModel = _navigationService.GetPrimaryNavigation();

            return View("~/Feature/Navigation/Views/PrimaryNavigation.cshtml", viewModel);
        }
    }
}