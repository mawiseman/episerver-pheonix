using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using Feature.Robots.Repositories;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Phoenix.Feature.Robots.Business
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class RobotsInitializationModule : IInitializableModule
    {
        private const string RobotsTxtRoute = "RobotsTxtRoute";

        private Lazy<IContentEvents> _contentEvents = new Lazy<IContentEvents>(() => ServiceLocator.Current.GetInstance<IContentEvents>());
        private IRobotsService _robotsService;

        public void Initialize(InitializationEngine context)
        {
            // Add the route mapping for /robots.txt

            RouteTable.Routes.MapRoute(
               RobotsTxtRoute,
               "robots.txt",
               new { controller = "RobotsTxt", action = "Index" });

            // Add an event handler to clear cache on publish even of 

            _contentEvents.Value.CreatingContent += CreatingContent;
            _contentEvents.Value.PublishedContent += PublishedContent;

            // load required services

            _robotsService = context.Locate.Advanced.GetService(typeof(IRobotsService)) as IRobotsService;            
        }

        public void Uninitialize(InitializationEngine context)
        {
            RouteTable.Routes.Remove(RouteTable.Routes[RobotsTxtRoute]);
        }

        private void CreatingContent(object sender, EPiServer.ContentEventArgs e)
        {
            bool shouldCancel = _robotsService.ShouldCancelRobotsSettingsPageCreation(e.Content.ContentTypeID);

            if(shouldCancel)
            {
                e.CancelAction = true;
                e.CancelReason = "A Robots Settings Page already exists";
            }
        }

        private void PublishedContent(object sender, EPiServer.ContentEventArgs e)
        {
            _robotsService.ClearRobotsCache(e.Content.ContentTypeID);
        }
    }
}