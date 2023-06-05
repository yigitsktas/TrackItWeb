using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Reflection;
using TrackItWeb.Helpers;
using TrackItWeb.Entities;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Health.Recipe
{
    public class RecipesModel : PageModel
    {
        private readonly APIService _apiService;

        public RecipesModel(APIService apiService)
        {
            _apiService = apiService;
        }

        public List<Recipes_DM>? Index_VM { get; set; }

        public async Task<IActionResult> OnGet()
        {
            List<Recipes_DM> model = new();

            var recipes = await _apiService.GetRecipes();

            if (recipes != null)
            {
                foreach (var item in recipes)
                {
                    Recipes_DM myRecipe = new Recipes_DM();

                    myRecipe.RecipeID = item.RecipeID;
                    myRecipe.GUID = item.GUID;
                    myRecipe.Title = item.Summary;
                    myRecipe.Directions = item.Directions;
                    myRecipe.Serve = item.Serve;
                    myRecipe.PrepTime = item.PrepTime;
                    myRecipe.CookTime = item.CookTime;
                    myRecipe.Ingredients = item.Ingredients;
                    myRecipe.Season = item.Season;
                    myRecipe.ServingType = item.ServingType;
                    myRecipe.HealthLevel = item.HealthLevel;

                    var member = await _apiService.GetMember(item.MemberID);

                    if (member != null)
                    {
                        myRecipe.CreatedBy = member.Username;
                    }

                    model.Add(myRecipe);
                }

                Index_VM = model;

                return Page();
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }

        public class Recipes_DM
        {
            public int RecipeID { get; set; }
            public Guid GUID { get; set; }
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
