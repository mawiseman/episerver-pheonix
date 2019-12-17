using EPiServer.Web.Mvc;
using Feature.Faq.Models.Blocks;

namespace Feature.Faq
{
    public class RegisterBlockViews : IViewTemplateModelRegistrator
    {
        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            viewTemplateModelRegistrator.Add(typeof(FaqBlock),
                new EPiServer.DataAbstraction.TemplateModel()
                {
                    Name = "FaqBlock",
                    Path = "~/Feature/Faq/Views/Blocks/FaqBlock.cshtml",
                    AvailableWithoutTag = true
                });
        }
    }
}