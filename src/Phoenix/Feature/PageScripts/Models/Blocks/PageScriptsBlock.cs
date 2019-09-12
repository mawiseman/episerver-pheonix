using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace Feature.PageScripts.Models.Blocks
{
    [ContentType(DisplayName = "Page Scripts", 
        GUID = "be19828e-8e07-4c0e-a030-981424b95630", 
        Description = "Provides section for marketers to page page scripts",
        AvailableInEditMode = false)]
    public class PageScriptsBlock : BlockData
    {
        [CultureSpecific]
        [Display(Name = "Page Head Script", Order = 100)]
        [UIHint(UIHint.Textarea)]
        public virtual string PageHeadScript { get; set; }

        [CultureSpecific]
        [Display(Name = "Page Body Start Script", Order = 200)]
        [UIHint(UIHint.Textarea)]
        public virtual string PageBodyStartScript { get; set; }

        [CultureSpecific]
        [Display(Name = "Page Body End Script", Order = 300)]
        [UIHint(UIHint.Textarea)]
        public virtual string PageBodyEndScript { get; set; }
    }
}