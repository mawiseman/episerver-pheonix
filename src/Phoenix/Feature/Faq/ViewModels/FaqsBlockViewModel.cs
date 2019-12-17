using Feature.Faq.Models.Blocks;
using System.Collections.Generic;

namespace Feature.Faq.Models.ViewModels
{
    public class FaqsBlockViewModel
    {
        public string Heading { get; set; }

        public List<FaqBlock> Faqs { get; set; }

        public FaqsBlockViewModel()
        {
            Faqs = new List<FaqBlock>();
        }
    }
}