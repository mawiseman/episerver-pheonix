using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Feature.Testimony.Models;
using Feature.Testimony.Models.Blocks;

namespace Feature.Testimony.Models.ViewModels
{
    public class TestimonyCarouselBlockViewModel
    {
        public string Heading{ get; set; }

        public string SubHeading { get; set; }

        public List<TestimonyBlock> Testimonies { get; set; }

        public TestimonyCarouselBlockViewModel()
        {
            Testimonies = new List<TestimonyBlock>();
        }
    }
}