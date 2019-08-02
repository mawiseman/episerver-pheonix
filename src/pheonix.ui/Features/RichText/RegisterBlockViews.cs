using EPiServer.Web.Mvc;
using Features.RichText.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Features.RichText
{
    public class RegisterBlockViews : IViewTemplateModelRegistrator
    {
        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            viewTemplateModelRegistrator.Add(typeof(RichTextBlock),
                new EPiServer.DataAbstraction.TemplateModel()
                {
                    Name = "RichTextBlock",
                    Path = "~/Features/RichText/Views/Blocks/RichTextBlock.cshtml",
                    AvailableWithoutTag = true
                });
        }
    }
}