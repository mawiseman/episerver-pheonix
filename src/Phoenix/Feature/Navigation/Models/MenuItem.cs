using EPiServer.Core;
using System.Collections.Generic;

namespace Feature.Navigation.Models
{
    public class MenuItem
    {
        public PageData Page { get; set; }
        public bool Selected { get; set; }
        public List<MenuItem> Children { get; set; }

        public MenuItem()
        {
            Children = new List<MenuItem>();
        }
    }
}