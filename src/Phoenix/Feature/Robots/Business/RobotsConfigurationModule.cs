using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using Feature.Robots.Repositories;

namespace Phoenix.Feature.Robots.Business
{
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class RobotsConfigurationModule : IConfigurableModule
    {
        void IConfigurableModule.ConfigureContainer(ServiceConfigurationContext context)
        {
            // Register Servies

            var services = context.Services;
            services.AddSingleton<IRobotsRepository, RobotsRepository>();
        }

        void IInitializableModule.Initialize(InitializationEngine context)
        {
        }

        void IInitializableModule.Uninitialize(InitializationEngine context)
        {
        }
    }
}