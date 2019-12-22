using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using Feature.Navigation.Services;

namespace Feature.Robots.Business
{
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class NavigationConfigurationModule : IConfigurableModule
    {
        void IConfigurableModule.ConfigureContainer(ServiceConfigurationContext context)
        {
            // Register Servies

            var services = context.Services;
            services.AddSingleton<INavigationService, NavigationService>();
        }

        void IInitializableModule.Initialize(InitializationEngine context)
        {
        }

        void IInitializableModule.Uninitialize(InitializationEngine context)
        {
        }
    }
}