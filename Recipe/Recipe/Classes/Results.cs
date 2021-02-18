using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.Classes
{
    public class Results
    {
        public string Title { get; set; }
        public string Href { get; set; }
        public string[] Ingredients { get; set; }
        public string Thumbnail { get; set; }
    }
}
