using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using TrackItWeb.Entities;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Health.MyRecipe
{
    public class UpdateRecipeModel : PageModel
    {
		private readonly APIService _apiService;

		public UpdateRecipeModel(APIService apiService)
		{
			_apiService = apiService;
		}

		[BindProperty]
		public TrackItWeb.Entities.Recipe? recipeUpdate { get; set; }

		public async Task<IActionResult> OnGet(Guid guid)
        {
			var recipe = await _apiService.GetRecipe(guid);

			recipeUpdate = recipe;

			return Page();
		}

		public async Task<IActionResult> OnPost(TrackItWeb.Entities.Recipe recipeUpdate)
		{
			var info = JsonConvert.SerializeObject(recipeUpdate);

			StringContent content = new StringContent(info, Encoding.UTF8, "application/json");

			var isOk = await _apiService.UpdateRecipe(content);

			if (isOk) { return Redirect("/Health/MyRecipe/UpdateRecipe?guid=" + recipeUpdate.GUID); }
			else { return RedirectToPage("/Error"); }

		}
	}
}
