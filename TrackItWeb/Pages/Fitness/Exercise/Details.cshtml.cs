using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using TrackItWeb.Entities;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Fitness.Exercise
{
	[Authorize]
	public class MSWorkoutDetailsModel : PageModel
	{
		private readonly APIService _apiService;

		public MSWorkoutDetailsModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public MSWDetail_DM Index_VM { get; set; }

		public async Task<IActionResult> OnGet(int id)
		{
			MSWDetail_DM model = new();

			var workout = await _apiService.GetMSWorkout(id);

			if (workout != null)
			{
				model.WorkoutID = workout.MemberSpecificWorkoutID;
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

		public class MSWDetail_DM
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
