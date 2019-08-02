using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell;
using EPiServer.SpecializedProperties;
using Features.MetaData.Models.Blocks;
using Features.MetaData.Models.Pages;
using Features.PageScripts.Models.Blocks;
using Features.PageScripts.Models.Pages;

namespace pheonix.ui.Models.Pages
{
    [ContentType(DisplayName = "Base Page",
        GUID = "8137AC21-BE4A-4B06-9C8D-440F7D23C2F1",
        Description = "")]
    [AvailableContentTypes(Include = new[] { typeof(StandardPage) })]
    public abstract class BasePage : PageData, IHasMetaData, IHasPageScripts
    {
        [Display(Name = "Meta Data", GroupName = "SEO", Order = 500)]
        public virtual MetaDataBlock MetaData { get; set; }

        [Display(Name = "Page Scripts", GroupName = "Page Scripts", Order = 600)]
        public virtual PageScriptsBlock PageScripts { get; set; }


        [CultureSpecific]
        [Display(Name = "Page Title", Order = 100)]
        public virtual string PageTitle { get; set; }


        [CultureSpecific]
        [Display(Name = "Main content area",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual ContentArea MainContent { get; set; }
    }
}