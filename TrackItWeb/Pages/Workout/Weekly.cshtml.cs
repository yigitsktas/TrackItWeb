using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TrackItWeb.Entities;

namespace TrackItWeb.Pages.Workout
{
	public class WeeklyModel : PageModel
	{
		public List<Weekly_DM> Index_VM { get; set; }

		public async Task<IActionResult> OnGet()
		{
			List<Weekly_DM> model = new();

			var client = new HttpClient();
			string url = "https://localhost:7004/api/Workout/GetWorkouts";

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var workouts = JsonConvert.DeserializeObject<List<TrackItWeb.Entities.Workout>>(await responseMessage.Content.ReadAsStringAsync());

				foreach (var item in workouts)
				{
					Weekly_DM workout = new();

					workout.WorkoutID = item.WorkoutID;
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
		public string? WorkoutName { get; set; }
		public int Difficulty { get; set; }
	}
}
