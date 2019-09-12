using Phoenix.Models.Pages;
using EPiServer.Web.Mvc;
using System.Web.Mvc;
using Phoenix.Models.ViewModels;

namespace Phoenix.Controllers
{
    public class StandardPageController : PageController<StandardPage>
    {
        public ActionResult Index(StandardPage currentPage)
        {
            var model = new PageViewModel<StandardPage>(currentPage);
            return View(model);
        }
    }
}