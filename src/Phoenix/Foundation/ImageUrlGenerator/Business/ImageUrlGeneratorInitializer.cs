using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using System.Web.Mvc;
using System.Web.Routing;

namespace Foundation.ImageUrlGenerator.Business
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class ImageUrlGeneratorInitializer : IInitializableModule
    {
        private bool initialised = false;

        public void Initialize(InitializationEngine context)
        {
            if (initialised)
                return;

            RouteTable.Routes.MapMvcAttributeRoutes();

            initialised = true;
        }

        public void Uninitialize(InitializationEngine context)
        {
            if (!initialised)
                return;

            initialised = false;
        }
    }
}