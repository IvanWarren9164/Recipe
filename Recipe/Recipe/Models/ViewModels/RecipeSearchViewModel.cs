using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.Models.ViewModels
{
    public class RecipeSearchViewModel
    {
        public string title { get; set; }
        public string ingredient { get; set; }
        public string page { get; set; }
    }
}
