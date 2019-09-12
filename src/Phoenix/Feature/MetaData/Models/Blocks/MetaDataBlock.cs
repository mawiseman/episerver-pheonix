using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Feature.MetaData.Models.Blocks
{
    [ContentType(
        DisplayName = "Meta Data",
        GUID = "8a90b957-b38b-4be9-a34d-20df6d6b7dfe",
        Description = "Meta Tags for SEO",
        AvailableInEditMode = false)]
    public class MetaDataBlock : BlockData
    {
        [CultureSpecific]
        [Display(Name = "Meta title", Order = 100)]
        public virtual string MetaTitle { get; set; }

        [CultureSpecific]
        [Display(Name = "Meta keywords", Order = 200)]
        public virtual string MetaKeywords { get; set; }

        [CultureSpecific]
        [Display(Name = "Meta description", Order = 300)]
        [UIHint(UIHint.Textarea)]     
        public virtual string MetaDescription { get; set; }

        [CultureSpecific]
        [Display(Name = "No Index", Description = "Tells a search engine not to index a page.", Order = 400)]
        public virtual bool NoIndex { get; set; }

        [CultureSpecific]
        [Display(Name = "No Follow", Description = "Tells a crawler not to follow any links on a page or pass along any link equity.", Order = 500)]
        public virtual bool NoFollow { get; set; }

        /// <summary>
        /// I'm not sure we should do this in a ContentType
        /// But is it worse to add a controller just for this and take a performance hit?
        /// The logic shouldn't be in a view either
        /// </summary>
        public virtual ICollection<string> MetaRobots
        {
            get
            {
                var robotsMetadata = new List<string>();

                if (NoIndex)
                {
                    robotsMetadata.Add("NOINDEX");
                }

                if (NoFollow)
                {
                    robotsMetadata.Add("NOFOLLOW");
                }

                return robotsMetadata;
            }
        }
    }
}
