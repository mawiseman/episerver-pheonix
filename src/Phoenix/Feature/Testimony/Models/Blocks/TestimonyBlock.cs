using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Foundation.ContentIcons.Business.DataAnnotations;
using Foundation.ImageUrlGenerator.Business.DataAnnotations;

namespace Feature.Testimony.Models.Blocks
{
    [ContentType(DisplayName = "Testimony", 
        GUID = "c8a9df4e-ef72-4aba-aeb1-8d9c558d1bcd", 
        AvailableInEditMode = false)]
    [ImageUrlGenerator("Testimony")]
    [ContentIcon(Foundation.ContentIcons.ContentIcon.Bubble)]
    public class TestimonyBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Name",
            Description = "The name of the person who wrote the testimony",
            Order = 1)]
        public virtual string Name { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Testimony",
            Description = "The authors testimony",
            Order = 2)]
        public virtual string Testimony { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Position",
            Description = "The authors position",
            Order = 3)]
        public virtual string Position { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Photo",
            Description = "A photo of the authors position",
            Order = 4)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Photo { get; set; }

    }
}