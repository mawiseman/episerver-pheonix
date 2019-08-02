using EPiServer.Web.Mvc;
using Features.Testimony.Models.Blocks;

namespace Features.Testimony
{
    public class RegisterBlockViews : IViewTemplateModelRegistrator
    {
        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            viewTemplateModelRegistrator.Add(typeof(TestimonyBlock),
                new EPiServer.DataAbstraction.TemplateModel()
                {
                    Name = "TestimonyBlock",
                    Path = "~/Features/Testimony/Views/Blocks/TestimonyBlock.cshtml",
                    AvailableWithoutTag = true
                });

            viewTemplateModelRegistrator.Add(typeof(TestimonyCarouselBlock),
                new EPiServer.DataAbstraction.TemplateModel()
                {
                    Name = "TestimonyCarouselBlock",
                    Path = "~/Features/Testimony/Views/Blocks/TestimonyCarouselBlock.cshtml",
                    AvailableWithoutTag = true
                });
        }
    }
}