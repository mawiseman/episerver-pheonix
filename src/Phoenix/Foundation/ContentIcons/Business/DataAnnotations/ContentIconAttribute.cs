using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation.ContentIcons.Business.DataAnnotations
{
    public class ContentIconAttribute : Attribute
    {
        public ContentIcon Icon { get; set; }

        public ContentIconColor Color { get; set; }

        public ContentIconAttribute(ContentIcon icon, ContentIconColor color = ContentIconColor.Default)
        {
            Icon = icon;
            Color = color;
        }
    }
}
