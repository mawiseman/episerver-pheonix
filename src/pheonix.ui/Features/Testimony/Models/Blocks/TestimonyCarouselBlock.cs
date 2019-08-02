using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Features.ImageUrlGenerator.Business.DataAnnotations;

namespace Features.Testimony.Models.Blocks
{
    [ContentType(DisplayName = "Testimony Carousel", 
        GUID = "d9e35fa7-9442-49d0-a414-51e4928e4eb1", 
        Description = "")]
    [ImageUrlGenerator("Testimonies")]
    public class TestimonyCarouselBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Sub Heading",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual string SubHeading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Testimonies",
            Description = "List of testimonies",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        [AllowedTypes(typeof(TestimonyBlock))]
        public virtual IList<ContentReference> Testimonies { get; set; }

    }
}