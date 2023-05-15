using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Reflection;
using TrackItWeb.Helpers;
using TrackItWeb.Entities;

namespace TrackItWeb.Pages.Nutrient
{
    public class RecipesModel : PageModel
    {
        public List<Recipes_DM>? Index_VM { get; set; }

        public async Task<IActionResult> OnGet()
        {
            List<Recipes_DM> model = new();

            var client = new HttpClient();
            string url = "https://localhost:7004/api/Nutrient/GetRecipes";

            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync(url);

            if (responseMessage.IsSuccessStatusCode == true)
            {
                var recipe = JsonConvert.DeserializeObject<List<Recipe>>(await responseMessage.Content.ReadAsStringAsync());

                if (recipe != null)
                {
                    foreach (var item in recipe)
                    {
                        Recipes_DM myRecipe = new Recipes_DM();

                        myRecipe.RecipeID = item.RecipeID;
                        myRecipe.Title = item.Summary;
                        myRecipe.Directions = item.Directions;
                        myRecipe.Serve = item.Serve;
                        myRecipe.PrepTime = item.PrepTime;
                        myRecipe.CookTime = item.CookTime;
                        myRecipe.Ingredients = item.Ingredients;
                        myRecipe.Season = item.Season;
                        myRecipe.ServingType = item.ServingType;
                        myRecipe.HealthLevel = item.HealthLevel;

                        url = "https://localhost:7004/api/Member/GetMember/" + item.MemberID;
                        HttpResponseMessage responseMessage1 = await client.GetAsync(url);
                        if (responseMessage1.IsSuccessStatusCode == true)
                        {
                            var member = JsonConvert.DeserializeObject<TrackItWeb.Entities.Member>(await responseMessage1.Content.ReadAsStringAsync());

                            if (member != null)
                            {
                                myRecipe.CreatedBy = member.Username;
                            }
                        }
                        model.Add(myRecipe);
                    }
                    Index_VM = model;
                }
            }
            else
            {
                return Page();
            }

            return Page();
        }

        public class Recipes_DM
        {
            public int RecipeID { get; set; }
            public string? Title { get; set; }
            public string? Directions { get; set; }
            public int Serve { get; set; }
            public int PrepTime { get; set; }
            public int CookTime { get; set; }
            public string? Ingredients { get; set; }
            public int Season { get; set; }
            public int ServingType { get; set; }
            public int HealthLevel { get; set; }
            public string? CreatedBy { get; set; }
        }
    }
}
