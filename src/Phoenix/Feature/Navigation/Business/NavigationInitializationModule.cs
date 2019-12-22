using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using Feature.Navigation.Services;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Feature.Navigation.Business
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class NavigationInitializationModule : IInitializableModule
    {
        private const string RobotsTxtRoute = "RobotsTxtRoute";

        private Lazy<IContentEvents> _contentEvents = new Lazy<IContentEvents>(() => ServiceLocator.Current.GetInstance<IContentEvents>());
        private INavigationService _navigationService;

        public void Initialize(InitializationEngine context)
        {
            // Add an event handler to clear cache on navigation changing events

            _contentEvents.Value.PublishedContent += PublishedContent;
            _contentEvents.Value.DeletedContent += PublishedContent;
            _contentEvents.Value.MovedContent += MovedContent;

            // load required services

            _navigationService = context.Locate.Advanced.GetService(typeof(INavigationService)) as INavigationService;            
        }

        public void Uninitialize(InitializationEngine context)
        {
            
        }

        private void PublishedContent(object sender, EPiServer.ContentEventArgs e)
        {
            _navigationService.ClearNavigationCache();
        }

        private void DeletedContent(object sender, EPiServer.ContentEventArgs e)
        {
            _navigationService.ClearNavigationCache();
        }

        private void MovedContent(object sender, EPiServer.ContentEventArgs e)
        {
            _navigationService.ClearNavigationCache();
        }
    }
}