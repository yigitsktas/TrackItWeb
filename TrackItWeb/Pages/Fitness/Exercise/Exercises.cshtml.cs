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
		public Dictionary<string, object> Parameters { get; set; }

		public async Task<IActionResult> OnGet(string searchString)
		{
			List<MSWorkoutDM> model = new();
			
			var workouts = await _apiService.GetMSWorkouts(User.GetMemberID());

			Dictionary<string, object> map = new()
			{
				{"SearchString", searchString},
			};

			Parameters = map;

			if (workouts != null)
			{
				foreach (var item in workouts.OrderByDescending(x => x.MemberSpecificWorkoutID))
				{
					MSWorkoutDM workout = new();

					workout.MSWorkoutID = item.MemberSpecificWorkoutID;
					workout.GUID = item.GUID;
					workout.WorkoutName = item.WorkoutName;

					model.Add(workout);
				}

				if (!string.IsNullOrEmpty(searchString))
				{
					Index_VM = model.Where(x => x.WorkoutName.ToLower().Contains(searchString)).ToList();
				}
				else
				{
					Index_VM = model;
				}

				return Page();
			}
			else
			{
				return Redirect("/Error");
			}
		}

		public async Task<IActionResult> OnPostDelete(Guid guid)
		{
			var isDeleted = await _apiService.DeleteMSWorkout(guid);

			if (isDeleted) { return RedirectToPage("/Fitness/Exercise/Exercises"); }
			else { return RedirectToPage("/Error"); }
		}
	}

	public class MSWorkoutDM
	{
		public int MSWorkoutID { get; set; }
		public Guid GUID { get; set; }
		public string? WorkoutName { get; set; }
	}
}
