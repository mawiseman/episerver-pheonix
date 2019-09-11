using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Mvc;
using Features.Testimony.Models.Blocks;
using Features.Testimony.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Features.Testimony.Controllers
{
    public class TestimonyCarouselBlockController : BlockController<TestimonyCarouselBlock>
    {
        private readonly IContentLoader contentLoader;

        public TestimonyCarouselBlockController(IContentLoader contentLoader)
        {
            this.contentLoader = contentLoader;
        }

        public override ActionResult Index(TestimonyCarouselBlock currentBlock)
        {
            var viewModel = new TestimonyCarouselBlockViewModel
            {
                Heading = currentBlock.Heading,
                SubHeading = currentBlock.SubHeading,
                Testimonies = contentLoader.GetItems(currentBlock.Testimonies, new LoaderOptions() { LanguageLoaderOption.FallbackWithMaster() }).Cast<TestimonyBlock>().ToList()
            };

            return PartialView("~/Features/Testimony/Views/TestimonyCarouselBlock/Index.cshtml", viewModel);
        }
    }
}
