using EPiServer.Web.Mvc;
using Feature.Testimony.Models.Blocks;

namespace Feature.Testimony
{
    public class RegisterBlockViews : IViewTemplateModelRegistrator
    {
        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            viewTemplateModelRegistrator.Add(typeof(TestimonyBlock),
                new EPiServer.DataAbstraction.TemplateModel()
                {
                    Name = "TestimonyBlock",
                    Path = "~/Feature/Testimony/Views/Blocks/TestimonyBlock.cshtml",
                    AvailableWithoutTag = true
                });

            viewTemplateModelRegistrator.Add(typeof(TestimonyCarouselBlock),
                new EPiServer.DataAbstraction.TemplateModel()
                {
                    Name = "TestimonyCarouselBlock",
                    Path = "~/Feature/Testimony/Views/Blocks/TestimonyCarouselBlock.cshtml",
                    AvailableWithoutTag = true
                });
        }
    }
}