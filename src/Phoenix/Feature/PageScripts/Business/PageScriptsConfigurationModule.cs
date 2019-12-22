using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using Feature.PageScripts.Services;

namespace Feature.PageScripts.Business
{
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class PageScriptsConfigurationModule : IConfigurableModule
    {
        void IConfigurableModule.ConfigureContainer(ServiceConfigurationContext context)
        {
            // Register Servies

            var services = context.Services;
            services.AddSingleton<IPageScriptService, PageScriptService>();
        }

        void IInitializableModule.Initialize(InitializationEngine context)
        {
        }

        void IInitializableModule.Uninitialize(InitializationEngine context)
        {
        }
    }
}