using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Feature.CallToAction.Models.Blocks;
using Feature.MetaData.Models.Blocks;
using Feature.MetaData.Models.Pages;
using Feature.PageScripts.Models.Blocks;
using Feature.PageScripts.Models.Pages;
using Feature.RichText.Models.Blocks;
using Feature.Testimony.Models.Blocks;
using Phoenix.Business.Site;

namespace Phoenix.Models.Pages
{
    public abstract class SitePageData : PageData, IHasMetaData, IHasPageScripts
    {
        [Display(Name = "Meta Data", GroupName = SiteTabNames.SEO)]
        public virtual MetaDataBlock MetaData { get; set; }

        [Display(Name = "Page Scripts", GroupName = SiteTabNames.PageScripts)]
        public virtual PageScriptsBlock PageScripts { get; set; }


        [CultureSpecific]
        [Display(Name = "Page Title",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string PageTitle { get; set; }

        [CultureSpecific]
        [Display(Name = "Main content area",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [AllowedTypes(new[] { typeof(RichTextBlock), typeof(CallToActionBlock), typeof(TestimonyCarouselBlock) })]
        public virtual ContentArea MainContent { get; set; }
    }
}