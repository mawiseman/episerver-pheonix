using pheonix.ui.Models.Pages;
using EPiServer.Web.Mvc;
using System.Web.Mvc;

namespace pheonix.ui.Controllers
{
    public class StartPageNoBlocksController : PageController<StartPageBlockProperties>
    {
        public ActionResult Index(StartPageBlockProperties currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            return View(currentPage);
        }
    }
}