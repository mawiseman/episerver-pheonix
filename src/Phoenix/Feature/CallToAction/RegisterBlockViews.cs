using EPiServer.Web.Mvc;
using Feature.CallToAction.Models.Blocks;

namespace Feature.CallToAction
{
    public class RegisterBlockViews : IViewTemplateModelRegistrator
    {
        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            viewTemplateModelRegistrator.Add(typeof(CallToActionBlock),
                new EPiServer.DataAbstraction.TemplateModel()
                {
                    Name = "CallToActionBlock",
                    Path = "~/Feature/CallToAction/Views/Blocks/CallToActionBlock.cshtml",
                    AvailableWithoutTag = true
                });
        }
    }
}