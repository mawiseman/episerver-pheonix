using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Foundation.ContentIcons.Business.DataAnnotations;
using Foundation.ImageUrlGenerator.Business.DataAnnotations;

namespace Feature.Faq.Models.Blocks
{
    [ContentType(DisplayName = "Faq", 
        GUID = "d5cff8bd-dad6-41df-8352-87cf4e2bbfe2", 
        Description = "A Frequently Asked Question")]
    [ImageUrlGenerator("FAQ")]
    [ContentIcon(Foundation.ContentIcons.ContentIcon.Bubble)]
    public class FaqBlock : BlockData
    {
        
        [CultureSpecific]
        [Display(
            Name = "Question",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Question { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Answer",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Answer { get; set; }

    }
}