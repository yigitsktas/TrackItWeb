using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackItWeb.Entities;
using TrackItWeb.Helpers;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Nutrient
{
    public class MyRecipesModel : PageModel
    {
		private readonly APIService _apiService;

		public MyRecipesModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public List<Recipe> IndexVM { get; set; }

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
    }
}
