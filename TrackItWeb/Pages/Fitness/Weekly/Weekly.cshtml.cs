using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TrackItWeb.Entities;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Fitness.Weekly
{
	[Authorize]
	public class WeeklyModel : PageModel
	{
		private readonly APIService _apiService;

		public WeeklyModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public List<Weekly_DM> Index_VM { get; set; }

		public async Task<IActionResult> OnGet()
		{
			List<Weekly_DM> model = new();

			var workouts = await _apiService.GetWorkouts();

			if (workouts != null)
			{
				foreach (var item in workouts)
				{
					Weekly_DM workout = new();

					workout.WorkoutID = item.WorkoutID;
					workout.GUID = item.GUID;
					workout.WorkoutName = item.WorkoutName;
					workout.Difficulty = item.Difficulty;

					model.Add(workout);
				}

				Index_VM = model;

				return Page();
			}
			else
			{
				return Redirect("/Error");
			}
		}
	}

	public class Weekly_DM
	{
		public int WorkoutID { get; set; }
		public Guid GUID { get; set; }
		public string? WorkoutName { get; set; }
		public int Difficulty { get; set; }
	}
}
