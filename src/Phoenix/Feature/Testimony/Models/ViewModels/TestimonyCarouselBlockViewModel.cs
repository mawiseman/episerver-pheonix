using Feature.Testimony.Models.Blocks;
using System.Collections.Generic;

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