using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Features.ImageUrlGenerator.Business.DataAnnotations
{
    public class ImageUrlGeneratorAttribute : ImageUrlAttribute
    {
        public ImageUrlGeneratorAttribute(string text)
            : base ("/" + Constants.ImageUrlGeneratorRoute + text)
        {
            
        }
    }
}