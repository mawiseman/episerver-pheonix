using EPiServer;
using EPiServer.Cms.Shell.Service;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using Feature.Robots.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phoenix.Feature.Robots.Controllers
{
    public class RobotsTxtController : Controller
    {
        private readonly IContentLoader _contentLoader;

        public RobotsTxtController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        [ContentOutputCache]
        public ActionResult Index()
        {
            var startPage = _contentLoader.Get<PageData>(SiteDefinition.Current.StartPage);

            if(startPage is IHasRobots)
            {
                string content = ((IHasRobots)startPage).Robots.Robots;
                return Content(content, "text/plain");
            }

            // TODO: Log an Error

            return new HttpNotFoundResult();
        }
    }
}