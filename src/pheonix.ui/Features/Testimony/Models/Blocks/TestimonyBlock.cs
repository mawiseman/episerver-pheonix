using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Features.ImageUrlGenerator.Business.DataAnnotations;

namespace Features.Testimony.Models.Blocks
{
    [ContentType(DisplayName = "Testimony", 
        GUID = "e7df45a1-3829-4eb1-af25-b268618232f1", 
        AvailableInEditMode = false)]
    [ImageUrlGenerator("Testimony")]
    public class TestimonyBlock : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Name",
            Description = "The name of the person who wrote the testimony",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Name { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Testimony",
            Description = "The authors testimony",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual string Testimony { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Position",
            Description = "The authors position",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual string Position { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Photo",
            Description = "A photo of the authors position",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Photo { get; set; }

    }
}