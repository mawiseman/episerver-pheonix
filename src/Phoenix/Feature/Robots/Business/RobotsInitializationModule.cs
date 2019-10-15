using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using System.Web.Mvc;
using System.Web.Routing;

namespace Phoenix.Feature.Robots.Business
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class RobotsInitializationModule : IInitializableModule
    {
        private const string RobotsTxtRoute = "RobotsTxtRoute";

        public void Initialize(InitializationEngine context)
        {
            RouteTable.Routes.MapRoute(
               RobotsTxtRoute,
               "robots.txt",
               new { controller = "RobotsTxt", action = "Index" });
        }

        public void Uninitialize(InitializationEngine context)
        {
            RouteTable.Routes.Remove(RouteTable.Routes[RobotsTxtRoute]);
        }
    }
}