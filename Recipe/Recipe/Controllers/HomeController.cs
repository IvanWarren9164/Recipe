using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recipe.Classes;
using Recipe.Models;
using Recipe.Models.ViewModels;
using Recipe.Services;
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
        private readonly RecipeContext _recipeDbContext;
        public HomeController(ILogger<HomeController> logger, RecipeClient recipeClient, RecipeContext recipeDbContext)
        {
            _logger = logger;
            _recipeClient = recipeClient;
            _recipeDbContext = recipeDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult RecipeIndex()
        {
            return View();
        }
        public async Task<IActionResult> RecipeIndexResult(RecipeSearchViewModel model)
        {
            var response = await _recipeClient.GetAllRecipes(model.ingredient, model.title, model.page);

            var viewModel = new RecipeIndexViewModel();

            viewModel.results = response.results
                .Select(response => new ResultsViewModel() { title = response.title, href = response.href, thumbnail = response.thumbnail })
                .ToList();

            return View(viewModel);
        }

        public IActionResult AddFavorite(string title, string href, string thumbnail)
        {
            var dbModel = new RecipeDAL();

            dbModel.title = title;
            dbModel.href = href;
            dbModel.thumbnail = thumbnail;

            _recipeDbContext.Favorites.Add(dbModel);
            _recipeDbContext.SaveChanges();

            return RedirectToAction("HomePage");
        }
        public IActionResult DeleteFavorite(int ID)
        {
            var recipe = GetRecipeWhereIdIsFirstOrDefault(ID);

            var recipeDAL = _recipeDbContext.Favorites.FirstOrDefault(recipeDal => recipeDal.ID == recipe.ID);

            _recipeDbContext.Favorites.Remove(recipeDAL);
            _recipeDbContext.SaveChanges();

            return RedirectToAction("HomePage");
        }
        public IActionResult FavoritesIndex()
        {
            var dbModel = new RecipeDAL();

            var RecipeList = _recipeDbContext.Favorites
                .Select(recipeDAL => new ResultsViewModel() { ID = recipeDAL.ID, title = recipeDAL.title, href = recipeDAL.href, thumbnail = recipeDAL.thumbnail })
                .ToList();

            var viewModel = new FavoritesViewModel();
            viewModel.results = RecipeList;

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private ResultsViewModel GetRecipeWhereIdIsFirstOrDefault(int id)
        {
            RecipeDAL recipeDAL = _recipeDbContext.Favorites
                .Where(recipe => recipe.ID == id)
                .FirstOrDefault();

            var recipe = new ResultsViewModel();
            recipe.ID = recipeDAL.ID;
            recipe.title = recipeDAL.title;
            recipe.href = recipeDAL.href;
            recipe.thumbnail = recipeDAL.thumbnail;

            return recipe;
        }
    }
}
