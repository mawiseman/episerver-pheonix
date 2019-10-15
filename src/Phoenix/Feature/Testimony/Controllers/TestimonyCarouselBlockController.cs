using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Mvc;
using Feature.Testimony.Models.Blocks;
using Feature.Testimony.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Feature.Testimony.Controllers
{
    public class TestimonyCarouselBlockController : BlockController<TestimonyCarouselBlock>
    {
        private readonly IContentLoader _contentLoader;

        public TestimonyCarouselBlockController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public override ActionResult Index(TestimonyCarouselBlock currentBlock)
        {
            var viewModel = new TestimonyCarouselBlockViewModel
            {
                Heading = currentBlock.Heading,
                SubHeading = currentBlock.SubHeading,
                Testimonies = _contentLoader.GetItems(currentBlock.Testimonies, new LoaderOptions() { LanguageLoaderOption.FallbackWithMaster() }).Cast<TestimonyBlock>().ToList()
            };

            return PartialView("~/Feature/Testimony/Views/TestimonyCarouselBlock/Index.cshtml", viewModel);
        }
    }
}
