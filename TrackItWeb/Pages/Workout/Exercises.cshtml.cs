using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TrackItWeb.Helpers;

namespace TrackItWeb.Pages.Workout
{
    public class ExercisesModel : PageModel
    {
		public List<MSWorkoutDM> Index_VM { get; set; }

		public async Task<IActionResult> OnGet()
		{
			List<MSWorkoutDM> model = new();

			var client = new HttpClient();
			string url = "https://localhost:7004/api/Workout/GetMSWorkouts/" + User.GetMemberID();

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var workouts = JsonConvert.DeserializeObject<List<TrackItWeb.Entities.MemberSpecificWorkout>>(await responseMessage.Content.ReadAsStringAsync());

				foreach (var item in workouts)
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
	}

	public class MSWorkoutDM
	{
		public int MSWorkoutID { get; set; }
		public string? WorkoutName { get; set; }
	}
}
