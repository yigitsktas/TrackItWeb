using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackItWeb.Entities;
using TrackItWeb.Helpers;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Health.MyRecipe
{
	[Authorize]
	public class MyRecipesModel : PageModel
    {
		private readonly APIService _apiService;

		public MyRecipesModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public List<TrackItWeb.Entities.Recipe> IndexVM { get; set; }

		public async Task<IActionResult> OnGet()
        {
			var memberRecipes = await _apiService.GetMemberRecipes(User.GetMemberID());

			if (memberRecipes != null)
			{
				IndexVM = memberRecipes;
				
				return Page();
			}
			else
			{
				return RedirectToPage("/Error");
			}
        }

		public async Task<IActionResult> OnPostDelete(int id)
		{
			var isDeleted = await _apiService.DeleteRecipe(id);

			if (isDeleted) { return RedirectToPage("/Health/MyRecipe/MyRecipes"); }
			else { return RedirectToPage("/Error"); }
		}
	}
}
