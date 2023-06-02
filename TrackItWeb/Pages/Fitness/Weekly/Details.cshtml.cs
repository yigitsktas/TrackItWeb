using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using TrackItWeb.Entities;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Fitness.Weekly
{
	[Authorize]
	public class WorkoutDetailsModel : PageModel
	{
		private readonly APIService _apiService;

		public WorkoutDetailsModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public WDetail_DM Index_VM { get; set; }

		public async Task<IActionResult> OnGet(int id)
		{
			WDetail_DM model = new();

			var workout = await _apiService.GetWorkout(id);

			if (workout != null)
			{
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

				var workoutType = await _apiService.GetWorkoutType(workout.WorkoutTypeID);

				if (workoutType != null)
				{
					model.WorkoutType = workoutType.Name;
				}
				else
				{
					model.WorkoutType = " ";
				}

				var muscleGroup = await _apiService.GetMuscleGroup(workout.MuscleGroupID);

				if (muscleGroup != null)
				{
					model.MuscleGroup = muscleGroup.Name;
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
