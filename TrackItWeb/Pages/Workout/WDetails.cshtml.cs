using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using TrackItWeb.Entities;

namespace TrackItWeb.Pages.Workout
{
	public class WorkoutDetailsModel : PageModel
	{
		public WDetail_DM Index_VM { get; set; }

		public async Task<IActionResult> OnGet(int id)
		{
			WDetail_DM model = new();

			var client = new HttpClient();
			string url = "https://localhost:7004/api/Workout/GetWorkout/" + id;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var workout = JsonConvert.DeserializeObject<TrackItWeb.Entities.Workout>(await responseMessage.Content.ReadAsStringAsync());

				model.WorkoutID = workout.WorkoutID;
				model.WorkoutName = workout.WorkoutName;
				model.Description = workout.Description;
				if (workout.Link != null) 
				{
					string link = " ";

					link = workout.Link.Replace("watch?v=", "embed/");
					model.Link = link;
				}
				else
				{
					model.Link = "";
				}
				model.Difficulty = workout.Difficulty;

				url = "https://localhost:7004/api/Workout/GetWorkoutType/" + workout.WorkoutTypeID;
				HttpResponseMessage responseMessage1 = await client.GetAsync(url);
				if (responseMessage1.IsSuccessStatusCode == true)
				{
					var workoutType = JsonConvert.DeserializeObject<TrackItWeb.Entities.WorkoutType>(await responseMessage1.Content.ReadAsStringAsync());

					if (workoutType != null)
					{
						model.WorkoutType = workoutType.Name;
					}
					else
					{
						model.WorkoutType = " ";
					}
				}

				else
				{
					model.WorkoutType = " ";
				}


				url = "https://localhost:7004/api/Workout/GetMuscleGroup/" + workout.MuscleGroupID;
				HttpResponseMessage responseMessage2 = await client.GetAsync(url);
				if (responseMessage2.IsSuccessStatusCode == true)
				{
					var muscleGroup = JsonConvert.DeserializeObject<TrackItWeb.Entities.MuscleGroup>(await responseMessage2.Content.ReadAsStringAsync());

					if (muscleGroup != null)
					{
						model.MuscleGroup = muscleGroup.Name;
					}
					else
					{
						model.MuscleGroup = " ";
					}
				}

				else
				{
					model.MuscleGroup = " ";
				}

				Index_VM = model;

				return Page();
			}
			else
			{
				return Redirect("/Error");
			}
		}

		public class WDetail_DM
		{
			public int WorkoutID { get; set; }
			public int Difficulty { get; set; }
			public string? WorkoutName { get; set; }
			public string? Description { get; set; }
			public string? MuscleGroup { get; set; }
			public string? WorkoutType { get; set; }
			public string? Link { get; set; }
		}
	}
}
