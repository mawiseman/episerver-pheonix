using EPiServer.Web.Mvc;
using Feature.Robots.Models.Pages;
using Feature.Robots.Services;
using System.Web.Mvc;

namespace Phoenix.Feature.Robots.Controllers
{
    public class RobotsTxtController : Controller
    {
        private readonly IRobotsService _robotsService;

        public RobotsTxtController(IRobotsService robotsService)
        {
            _robotsService = robotsService;
        }

        [HttpGet]
        [ContentOutputCache]
        public ActionResult Index(bool? ignoreCache = false)
        {
            var robotsSettingPage = _robotsService.GetRobots(ignoreCache.Value);

            if(robotsSettingPage is IHasRobots)
            {
                return Content(robotsSettingPage.Robots.Robots, "text/plain");
            }

            return new HttpNotFoundResult();
        }
    }
}