using Recipe.Models;
using Recipe.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Recipe
{
    public class RecipeClient
    {
        private readonly HttpClient _client;

        public RecipeClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<RecipeViewModel> GetAllRecipes()
        {
            return await GetAsync<RecipeViewModel>("/api/");
        }


        private async Task<T> GetAsync<T>(string endPoint)
        {
            // Post    -  Insert    -  Create
            // Get     -  Select    -  Read
            // Put     -  Update    -  Update
            // Delete  -  Delete    -  Delete


            var response = await _client.GetAsync(endPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();

                // var jsonOptions = new JsonSerializerOptions();

                var model = await JsonSerializer.DeserializeAsync<T>(content);

                return model;
            }
            else
            {
                throw new HttpRequestException("Recipe Puppy API returned bad response");
            }
        }
    }
}
