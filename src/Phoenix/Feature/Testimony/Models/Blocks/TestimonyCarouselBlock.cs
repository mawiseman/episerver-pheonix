using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Foundation.ContentIcons.Business.DataAnnotations;
using Foundation.ImageUrlGenerator.Business.DataAnnotations;

namespace Feature.Testimony.Models.Blocks
{
    [ContentType(DisplayName = "Testimony Carousel", 
        GUID = "e61d4743-a734-406b-abc9-35bdcf193d53", 
        Description = "")]
    [ImageUrlGenerator("Testimonies")]
    [ContentIcon(Foundation.ContentIcons.ContentIcon.Tiles)]
    public class TestimonyCarouselBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Order = 1)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Sub Heading",
            Order = 2)]
        public virtual string SubHeading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Testimonies",
            Description = "List of testimonies",
            Order = 3)]
        [AllowedTypes(typeof(TestimonyBlock))]
        public virtual IList<ContentReference> Testimonies { get; set; }

    }
}