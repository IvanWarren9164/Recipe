using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.Models.ViewModels
{
    public class ResultsViewModel
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string href { get; set; }
        //public string[] ingredients { get; set; }
        public string thumbnail { get; set; }
    }
}
