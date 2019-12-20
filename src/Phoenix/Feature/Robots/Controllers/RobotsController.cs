using EPiServer;
using EPiServer.Cms.Shell.Service;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using Feature.Robots.Models.Pages;
using Feature.Robots.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phoenix.Feature.Robots.Controllers
{
    public class RobotsTxtController : Controller
    {
        private readonly IRobotsRepository _robotsRepository;

        public RobotsTxtController(IRobotsRepository robotsRepository)
        {
            _robotsRepository = robotsRepository;
        }

        [HttpGet]
        [ContentOutputCache]
        public ActionResult Index()
        {
            var robotsSettingPage = _robotsRepository.GetRobots();

            if(robotsSettingPage is IHasRobots)
            {
                return Content(robotsSettingPage.Robots.Robots, "text/plain");
            }

            return new HttpNotFoundResult();
        }
    }
}