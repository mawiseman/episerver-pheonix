using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace Features.Media.Models
{
    [ContentType(DisplayName = "Image File",
        GUID = "b22a9250-9b44-4c7e-a63d-6b8bca582a92",
        Description = "Use this to upload images")]
    [MediaDescriptor(ExtensionString = "png,gif,jpg,jpeg")]
    public class ImageFile : ImageData
    {

        [CultureSpecific]
        [Editable(true)]
        public virtual string Description { get; set; }
    }
}