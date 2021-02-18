using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recipe.Classes;
using Recipe.Models;
using Recipe.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RecipeClient _recipeClient;
        public HomeController(ILogger<HomeController> logger, RecipeClient recipeClient)
        {
            _logger = logger;
            _recipeClient = recipeClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> RecipeIndex()
        {
            var response = await _recipeClient.GetAllRecipes();

            var viewModel = new RecipeIndexViewModel();

            viewModel.Index[0].Title = response.results[0].Title;
            

            //var viewModel = new RecipeIndexViewModel();
            //viewModel.Recipes = response
            //    .Select(response => new ResultsViewModel() { Title = response.title })
            //    .ToList();

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
