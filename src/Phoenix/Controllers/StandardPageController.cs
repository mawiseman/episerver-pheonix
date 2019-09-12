using Pheonix.Models.Pages;
using EPiServer.Web.Mvc;
using System.Web.Mvc;
using Pheonix.Models.ViewModels;

namespace Pheonix.Controllers
{
    public class StandardPageController : PageController<StandardPage>
    {
        public ActionResult Index(StandardPage currentPage)
        {
            var model = new SitePageViewModel<StandardPage>(currentPage);
            return View(model);
        }
    }
}