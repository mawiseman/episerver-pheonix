using EPiServer.Web.Mvc;
using Features.CallToAction.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Features.CallToAction
{
    public class RegisterBlockViews : IViewTemplateModelRegistrator
    {
        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            viewTemplateModelRegistrator.Add(typeof(CallToActionBlock),
                new EPiServer.DataAbstraction.TemplateModel()
                {
                    Name = "CallToActionBlock",
                    Path = "~/Features/CallToAction/Views/Blocks/CallToActionBlock.cshtml",
                    AvailableWithoutTag = true
                });
        }
    }
}