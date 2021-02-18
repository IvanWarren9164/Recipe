using Recipe.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.Models
{
    public class RecipeViewModel
    {
        //public RecipeViewModel(Results[] results)
        //{
        //    results = new results;
        //}

        public string title { get; set; }
        public double version { get; set; }
        public string href { get; set; }
        public Results[] results { get; set; }
    }
}
