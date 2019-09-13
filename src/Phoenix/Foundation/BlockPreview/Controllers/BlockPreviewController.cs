using System.Linq;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer;
using EPiServer.Framework.Web.Mvc;
using Phoenix.Models.Pages;
using Foundation.BlockPreview.Models.ViewModels;

namespace Foundation.BlockPreview.Controllers
{
    [TemplateDescriptor(
        Inherited = true,
        TemplateTypeCategory = TemplateTypeCategories.MvcController, //Required as controllers for blocks are registered as MvcPartialController by default
        Tags = new[] { RenderingTags.Preview, RenderingTags.Edit },
        AvailableWithoutTag = false)]
    [VisitorGroupImpersonation]
    [RequireClientResources]
    public class BlockPreviewController : ActionControllerBase, IRenderTemplate<BlockData>
    {
        private readonly IContentLoader _contentLoader;
        private readonly TemplateResolver _templateResolver;
        private readonly DisplayOptions _displayOptions;

        public BlockPreviewController(IContentLoader contentLoader, TemplateResolver templateResolver, DisplayOptions displayOptions)
        {
            _contentLoader = contentLoader;
            _templateResolver = templateResolver;
            _displayOptions = displayOptions;
        }

        public ActionResult Index(IContent currentContent)
        {
            //As the layout requires a page for title etc we "borrow" the start page
            var startPage = _contentLoader.Get<SitePageData>(SiteDefinition.Current.StartPage);

            var model = new BlockPreviewModel(startPage, currentContent);

            var supportedDisplayOptions = _displayOptions
                .Select(x => new { Tag = x.Tag, Name = x.Name, Supported = SupportsTag(currentContent, x.Tag) })
                .ToList();

            var contentArea = new ContentArea();
            contentArea.Items.Add(new ContentAreaItem
            {
                ContentLink = currentContent.ContentLink
            });

            if (supportedDisplayOptions.Any(x => x.Supported))
            {
                foreach (var displayOption in supportedDisplayOptions)
                {
                    var areaModel = new BlockPreviewModel.PreviewArea
                    {
                        Supported = displayOption.Supported,
                        AreaTag = displayOption.Tag,
                        AreaName = displayOption.Name,
                        ContentArea = contentArea
                    };
                    model.Areas.Add(areaModel);
                }
            }
            else
            {
                // if no displayOptions are registered lets throw in a default one... not sure if this is bad or not
                var areaModel = new BlockPreviewModel.PreviewArea
                {
                    Supported = true,
                    AreaName = "Preview Only",
                    ContentArea = contentArea
                };
                model.Areas.Add(areaModel);
            }

            return View("~/Foundation/BlockPreview/Views/BlockPreview/Index.cshtml", model);
        }

        private bool SupportsTag(IContent content, string tag)
        {
            var templateModel = _templateResolver.Resolve(HttpContext,
                                    content.GetOriginalType(),
                                    content,
                                    TemplateTypeCategories.MvcPartial,
                                    tag);

            return templateModel != null;
        }
    }
}