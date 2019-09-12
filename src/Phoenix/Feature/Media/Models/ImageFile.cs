using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace Feature.Media.Models
{
    [ContentType(DisplayName = "Image File",
        GUID = "ecef132d-b39a-4476-b3de-95e46aea7732",
        Description = "Use this to upload images")]
    [MediaDescriptor(ExtensionString = "png,gif,jpg,jpeg")]
    public class ImageFile : ImageData
    {

        [CultureSpecific]
        [Editable(true)]
        public virtual string Description { get; set; }
    }
}