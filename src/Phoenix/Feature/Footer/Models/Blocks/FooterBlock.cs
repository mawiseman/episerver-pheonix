using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Feature.Footer.Models.Blocks
{
    [ContentType(DisplayName = "Footer", 
        GUID = "951bfd54-33b3-41c1-87a0-639fde42eab3", 
        Description = "")]
    public class FooterBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Column One Title",
            Description = "Column one title",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string ColumnOneTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Column One",
            Description = "Column one content",
            GroupName = SystemTabNames.Content,
            Order = 11)]
        public virtual XhtmlString ColumnOne { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Column Two Title",
            Description = "Column two title",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string ColumnTwoTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Column Two",
            Description = "Column two content",
            GroupName = SystemTabNames.Content,
            Order = 21)]
        public virtual XhtmlString ColumnTwo { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Column Three Title",
            Description = "Column three title",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual string ColumnThreeTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Column Three",
            Description = "Column three content",
            GroupName = SystemTabNames.Content,
            Order = 31)]
        public virtual XhtmlString ColumnThree { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Copyright",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual string Copyright { get; set; }
    }
}