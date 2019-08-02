using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using System.Linq;
using System.Web.Mvc;

namespace Features.ViewFolders.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class ViewFoldersInitializer : IInitializableModule
    {
        private bool initialised = false;

        public void Initialize(InitializationEngine context)
        {
            if (initialised)
                return;

            ViewEngines.Engines.Add(new ViewFolderRazorViewEngine());

            initialised = true;
        }

        public void Uninitialize(InitializationEngine context)
        {
            if (!initialised)
                return;

            var razorViewEngine = ViewEngines.Engines.FirstOrDefault(e => e is ViewFolderRazorViewEngine);

            if (razorViewEngine != null)
                ViewEngines.Engines.Remove(razorViewEngine);

            initialised = false;
        }
    }
}