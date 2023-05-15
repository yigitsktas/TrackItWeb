using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TrackItWeb.Entities;

namespace TrackItWeb.Pages.Nutrient
{
	public class RDetailsModel : PageModel
	{
		public Recipe_Details_DM? Index_VM { get; set; }

		public async Task<IActionResult> OnGet(int id)
		{
			Recipe_Details_DM model = new();

			var client = new HttpClient();
			string url = "https://localhost:7004/api/Nutrient/GetRecipe/" + id;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var recipe = JsonConvert.DeserializeObject<Recipe>(await responseMessage.Content.ReadAsStringAsync());

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

					url = "https://localhost:7004/api/Member/GetMember/" + recipe.MemberID;
					HttpResponseMessage responseMessage1 = await client.GetAsync(url);
					if (responseMessage1.IsSuccessStatusCode == true)
					{
						var member = JsonConvert.DeserializeObject<TrackItWeb.Entities.Member>(await responseMessage1.Content.ReadAsStringAsync());

						if (member != null)
						{
							model.CreatedBy = member.Username;
						}
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
