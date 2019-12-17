using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Foundation.ContentIcons.Business.DataAnnotations;
using Foundation.ImageUrlGenerator.Business.DataAnnotations;

namespace Feature.Faq.Models.Blocks
{
    [ContentType(DisplayName = "Faq Collection", 
        GUID = "bd054ffc-e02e-49b8-8309-fa286a612574", 
        Description = "Collection of Frequently Asked Questions")]
    [ImageUrlGenerator("FAQs")]
    [ContentIcon(Foundation.ContentIcons.ContentIcon.List)]
    public class FaqsBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Title",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Frequently Asked Questions",
            Description = "List of Frequently Asked Question",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [AllowedTypes(typeof(FaqBlock))]
        public virtual IList<ContentReference> FaqItems { get; set; }
    }
}