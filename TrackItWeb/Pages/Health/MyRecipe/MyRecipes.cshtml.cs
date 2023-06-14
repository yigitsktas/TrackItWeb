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
		public Dictionary<string, object> Parameters { get; set; }

		public async Task<IActionResult> OnGet(string searchString)
        {
			var memberRecipes = await _apiService.GetMemberRecipes(User.GetMemberID());

			Dictionary<string, object> map = new()
			{
				{"SearchString", searchString},
			};

			Parameters = map;

			if (memberRecipes != null)
			{
				if (!string.IsNullOrEmpty(searchString))
				{
					IndexVM = memberRecipes.Where(x => x.Summary.ToLower().Contains(searchString)).ToList();
				}
				else
				{
					IndexVM = memberRecipes;
				}
				
				return Page();
			}
			else
			{
				return RedirectToPage("/Error");
			}
        }

		public async Task<IActionResult> OnPostDelete(Guid guid)
		{
			var isDeleted = await _apiService.DeleteRecipe(guid);

			if (isDeleted) { return RedirectToPage("/Health/MyRecipe/MyRecipes"); }
			else { return RedirectToPage("/Error"); }
		}
	}
}
