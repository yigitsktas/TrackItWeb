using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackItWeb.Entities;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Home
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
		private readonly APIService _apiService;

		public IndexModel(APIService apiService)
		{
			_apiService = apiService;
		}

        public IndexVM MyModel { get; set; }

	    public async Task<IActionResult> OnGet()
        {
            IndexVM model = new IndexVM();  

            var workouts = await _apiService.GetRandomWorkouts();    
            var recipes = await _apiService.GetRandomRecipes();

            if (workouts != null){ model.Workouts = workouts; }

            if (recipes != null){ model.Recipes = recipes; }

            MyModel = model;

            return Page();
        }

        public class IndexVM
        {
            public List<TrackItWeb.Entities.Workout>? Workouts { get; set; }
            public List<Recipe>? Recipes { get; set; }
        }
    }
}
