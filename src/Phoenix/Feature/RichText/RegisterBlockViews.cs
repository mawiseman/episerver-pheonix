using EPiServer.Web.Mvc;
using Feature.RichText.Models.Blocks;

namespace Feature.RichText
{
    public class RegisterBlockViews : IViewTemplateModelRegistrator
    {
        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            viewTemplateModelRegistrator.Add(typeof(RichTextBlock),
                new EPiServer.DataAbstraction.TemplateModel()
                {
                    Name = "RichTextBlock",
                    Path = "~/Feature/RichText/Views/Blocks/RichTextBlock.cshtml",
                    AvailableWithoutTag = true
                });
        }
    }
}