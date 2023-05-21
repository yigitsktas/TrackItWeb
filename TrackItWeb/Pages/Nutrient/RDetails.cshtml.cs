using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TrackItWeb.Entities;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Nutrient
{
	public class RDetailsModel : PageModel
	{
		private readonly APIService _apiService;

		public RDetailsModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public Recipe_Details_DM? Index_VM { get; set; }

		public async Task<IActionResult> OnGet(int id)
		{
			Recipe_Details_DM model = new();

			var recipe = await _apiService.GetRecipe(id);

			if (recipe != null)
			{
				model.RecipeID = recipe.RecipeID;
				model.Title = recipe.Summary;
				model.Directions = recipe.Directions;
				model.Serve = recipe.Serve;
				model.PrepTime = recipe.PrepTime;
				model.CookTime = recipe.CookTime;
				model.Ingredients = recipe.Ingredients;
				if (recipe.Season == 1)
				{
					model.Season = "spring.";
				}
				model.ServingType = recipe.ServingType;
				model.HealthLevel = recipe.HealthLevel;

				var member = await _apiService.GetMember(recipe.MemberID);

				if (member != null)
				{
					model.CreatedBy = member.Username;
				}

				Index_VM = model;

				return Page();
			}

			else
			{
				return RedirectToPage("/Error");
			}

		}

		public class Recipe_Details_DM
		{
			public int RecipeID { get; set; }
			public string? Title { get; set; }
			public string? Directions { get; set; }
			public int Serve { get; set; }
			public int PrepTime { get; set; }
			public int CookTime { get; set; }
			public string? Ingredients { get; set; }
			public string? Season { get; set; }
			public int ServingType { get; set; }
			public int HealthLevel { get; set; }
			public string? CreatedBy { get; set; }
		}
	}
}
