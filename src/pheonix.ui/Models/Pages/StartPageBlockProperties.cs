using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Features.CallToAction.Models.Blocks;
using Features.ContentIcons;
using Features.ContentIcons.Business.DataAnnotations;
using Features.ImageUrlGenerator.Business.DataAnnotations;
using Features.RichText.Models.Blocks;
using Features.Testimony.Models.Blocks;
using System.ComponentModel.DataAnnotations;

namespace pheonix.ui.Models.Pages
{
    [ContentType(DisplayName = "Start Page Block Properties",
        GUID = "5C26B71A-5490-4574-95B6-2D58ACC9B001",
        Description = "")]
    [AvailableContentTypes(Include = new[] { typeof(StandardPage) })]
    [ContentIcon(ContentIcon.ObjectStart)]
    [ImageUrlGenerator("Start Page No Blocks")]
    public class StartPageBlockProperties : BasePage
    {

        [Display(Name = "Call To Action ", Order = 100)]
        public virtual CallToActionBlock CallToAction { get; set; }


        [Display(Name = "Rich Text", Order = 200)]
        public virtual RichTextBlock RichText { get; set; }

        [Display(Name = "Testimonials", Order = 300)]
        public virtual TestimonyCarouselBlock Testimonials { get; set; }
    }

    /// <summary>
    /// Should probably be in its own file... but while "Pages" are here im keeping it togethere
    /// </summary>
    //[UIDescriptorRegistration]
    //public class StartPageUIDescriptor : UIDescriptor<StartPage>
    //{
    //    public StartPageUIDescriptor() : base("dijitIcon")
    //    {
    //        IconClass = Avanade.EPiServer.Ux.Css.ObjectIcons.Start;
    //    }
    //}
}