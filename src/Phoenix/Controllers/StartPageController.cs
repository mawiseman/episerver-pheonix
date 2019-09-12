using Phoenix.Models.Pages;
using EPiServer.Web.Mvc;
using System.Web.Mvc;
using Phoenix.Models.ViewModels;

namespace Phoenix.Controllers
{
    public class StartPageController : PageController<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            var model = new PageViewModel<StartPage>(currentPage);
            return View(model);
        }
    }
}