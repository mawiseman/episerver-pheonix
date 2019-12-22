using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using Feature.PageScripts.Services;
using System;

namespace Feature.PageScripts.Business
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class RobotsInitializationModule : IInitializableModule
    {
        private readonly Lazy<IContentEvents> _contentEvents = new Lazy<IContentEvents>(() => ServiceLocator.Current.GetInstance<IContentEvents>());
        private IPageScriptService _pageScriptService;

        public void Initialize(InitializationEngine context)
        {
            // Add an event handler to clear cache on publish even of 

            _contentEvents.Value.CreatingContent += CreatingContent;
            _contentEvents.Value.PublishedContent += PublishedContent;

            // load required services

            _pageScriptService = context.Locate.Advanced.GetService(typeof(IPageScriptService)) as IPageScriptService;            
        }

        public void Uninitialize(InitializationEngine context)
        {
           
        }

        private void CreatingContent(object sender, EPiServer.ContentEventArgs e)
        {
            bool shouldCancel = _pageScriptService.ShouldCancelGlobalPageScriptPageCreation(e.Content.ContentTypeID);

            if(shouldCancel)
            {
                e.CancelAction = true;
                e.CancelReason = "A Page Scrpts Settings Page already exists";
            }
        }

        private void PublishedContent(object sender, EPiServer.ContentEventArgs e)
        {
            _pageScriptService.ClearRobotsCache(e.Content.ContentTypeID);
        }
    }
}