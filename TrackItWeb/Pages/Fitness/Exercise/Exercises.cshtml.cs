using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TrackItWeb.Entities;
using TrackItWeb.Helpers;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Fitness.Exercise
{
	[Authorize]

	public class ExercisesModel : PageModel
    {
		private readonly APIService _apiService;

		public ExercisesModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public List<MSWorkoutDM> Index_VM { get; set; }

		public async Task<IActionResult> OnGet()
		{
			List<MSWorkoutDM> model = new();
			
			var workouts = await _apiService.GetMSWorkouts(User.GetMemberID());	

			if (workouts != null)
			{
				foreach (var item in workouts.OrderByDescending(x => x.MemberSpecificWorkoutID))
				{
					MSWorkoutDM workout = new();

					workout.MSWorkoutID = item.MemberSpecificWorkoutID;
					workout.WorkoutName = item.WorkoutName;

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

		public async Task<IActionResult> OnPostDelete(int id)
		{
			var isDeleted = await _apiService.DeleteMSWorkout(id);

			if (isDeleted) { return RedirectToPage("/Fitness/Exercise/Exercises"); }
			else { return RedirectToPage("/Error"); }
		}
	}

	public class MSWorkoutDM
	{
		public int MSWorkoutID { get; set; }
		public string? WorkoutName { get; set; }
	}
}
