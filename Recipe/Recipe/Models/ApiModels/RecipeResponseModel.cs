using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.Models.ApiModels
{
    public class RecipeResponseModel
    {
        public string title { get; set; }
        public string version { get; set; }
        public string href { get; set; }
        public string[] results { get; set; }
    }
}
