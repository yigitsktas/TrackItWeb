using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TrackItWeb.Entities;
using TrackItWeb.Helpers;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Nutrient
{
    public class AddRecipesModel : PageModel
    {
		private readonly APIService _apiService;

		public AddRecipesModel(APIService apiService)
		{
			_apiService = apiService;
		}

		[BindProperty]
        public Recipe? recipeAdd { get; set; }

        public async Task<IActionResult> OnPost()
        {
            recipeAdd.MemberID = User.GetMemberID();
            recipeAdd.Serve = 1;

            var info = JsonConvert.SerializeObject(recipeAdd);

            var isTrue = await _apiService.CreateRecipe(info);

            if (isTrue)
            {
                return RedirectToPage("/Nutrient/MyRecipes");
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
