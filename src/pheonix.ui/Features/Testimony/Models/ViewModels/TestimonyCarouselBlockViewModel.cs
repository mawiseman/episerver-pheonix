using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Features.Testimony.Models;
using Features.Testimony.Models.Blocks;

namespace Features.Testimony.Models.ViewModels
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