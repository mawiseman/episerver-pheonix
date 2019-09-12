using Pheonix.Models.Pages;
using EPiServer.Web.Mvc;
using System.Web.Mvc;
using Pheonix.Models.ViewModels;

namespace Pheonix.Controllers
{
    public class StartPageController : PageController<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            var model = new SitePageViewModel<StartPage>(currentPage);
            return View(model);
        }
    }
}