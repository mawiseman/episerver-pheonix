using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Mvc;
using Feature.Faq.Models.Blocks;
using Feature.Faq.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Feature.Faq.Controllers
{
    public class FaqsBlockController : BlockController<FaqsBlock>
    {
        private readonly IContentLoader _contentLoader;

        public FaqsBlockController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public override ActionResult Index(FaqsBlock currentBlock)
        {
            var viewModel = new FaqsBlockViewModel();

            if (currentBlock != null)
            {
                viewModel = new FaqsBlockViewModel
                {
                    Heading = currentBlock.Title
                };

                if(currentBlock.FaqItems != null)
                {
                    viewModel.Faqs = _contentLoader
                        .GetItems(currentBlock.FaqItems, new LoaderOptions() { LanguageLoaderOption.FallbackWithMaster() })
                        .Cast<FaqBlock>()
                        .ToList();
                }
            }

            return PartialView("~/Feature/Faq/Views/FaqsBlock/Index.cshtml", viewModel);
        }
    }
}