using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TrackItWeb.DataModels;
using TrackItWeb.Entities;
using TrackItWeb.Helpers;

namespace TrackItWeb.Pages.Workout
{
	public class MSWAddNewModel : PageModel
	{
		public SelectList? WorkoutTypes { get; set; }
		public SelectList? MuscleGroups { get; set; }

		public async Task<IActionResult> OnGet()
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Workout/GetWorkoutTypes";
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var workoutTypes = JsonConvert.DeserializeObject<List<TrackItWeb.Entities.WorkoutType>>(await responseMessage.Content.ReadAsStringAsync());

				WorkoutTypes = new SelectList(workoutTypes, nameof(WorkoutType.WorkoutTypeID), nameof(WorkoutType.Name));

				url = "https://localhost:7004/api/Workout/GetMuscleGroups";
				HttpResponseMessage responseMessage1 = await client.GetAsync(url);

				if (responseMessage1.IsSuccessStatusCode == true)
				{
					var muscleGroups = JsonConvert.DeserializeObject<List<TrackItWeb.Entities.MuscleGroup>>(await responseMessage1.Content.ReadAsStringAsync());

					MuscleGroups = new SelectList(muscleGroups, nameof(MuscleGroup.MuscleGroupID), nameof(MuscleGroup.Name));

					return Page();
				}

				else
				{
					return RedirectToPage("/Error");
				}
			}
			else
			{
				return RedirectToPage("/Error");
			}
		}

		[BindProperty]
		public MSWorkoutAddDM? workoutAddDM { get; set; }

		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				MSWorkoutAddDM msworkout = new MSWorkoutAddDM();

				msworkout.MemberID = User.GetMemberID();
				msworkout.WorkoutName = workoutAddDM.WorkoutName;
				msworkout.MuscleGroupID = workoutAddDM.MuscleGroupID;
				msworkout.WorkoutTypeID = workoutAddDM.WorkoutTypeID;
				msworkout.Description = workoutAddDM.Description;
				if (workoutAddDM.Link.Contains("https://www.youtube.com/watch?v="))
				{
					msworkout.Link = workoutAddDM.Link.Replace("https://www.youtube.com/watch?v=", "");
				}
				else
				{
					msworkout.Link = " ";
				}

				var info = JsonConvert.SerializeObject(msworkout);

				var client = new HttpClient();
				string url = "https://localhost:7004/api/Workout/CreateMSWorkout/" + info;
				client.BaseAddress = new Uri(url);
				HttpResponseMessage responseMessage = await client.GetAsync(url);

				if (responseMessage.IsSuccessStatusCode == true)
				{
					return RedirectToPage("/Exercises"); 
				}
				else
				{
					return RedirectToPage("/Error"); 
				}
			}
			else
			{
				return RedirectToPage("/Error"); 
			}
		}
	}
}
