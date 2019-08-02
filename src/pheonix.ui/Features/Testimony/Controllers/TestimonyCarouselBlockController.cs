using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using Features.Testimony.Models.Blocks;
using Features.Testimony.Models.ViewModels;

namespace Features.Testimony.Controllers
{
    public class TestimonyCarouselBlockController : BlockController<TestimonyCarouselBlock>
    {
        public override ActionResult Index(TestimonyCarouselBlock currentBlock)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();

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
