using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;

namespace Foundation.Media.Models
{
    [ContentType(GUID = "C97D1822-7E95-43CB-B832-A05DC772005A")]
    [MediaDescriptor(ExtensionString = "flv,mp4,webm,m4v")]
    public class VideoFile : VideoData
    {
        /// <summary>
        /// Gets or sets the copyright.
        /// </summary>
        public virtual string Copyright { get; set; }

        /// <summary>
        /// Gets or sets the URL to the preview image.
        /// </summary>
        [UIHint(UIHint.Image)]
        public virtual ContentReference PreviewImage { get; set; }
    }
}
