using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TrackItWeb.DataModels;
using TrackItWeb.Entities;
using TrackItWeb.Helpers;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Fitness.Exercise
{
	[Authorize]
	public class MSWAddNewModel : PageModel
	{
		private readonly APIService _apiService;

		public MSWAddNewModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public SelectList? WorkoutTypes { get; set; }
		public SelectList? MuscleGroups { get; set; }

		public async Task<IActionResult> OnGet()
		{
			var workoutTypes = await _apiService.GetWorkoutTypes();
			if (workoutTypes == null) { new SelectList(Enumerable.Empty<SelectListItem>()); }
			else { WorkoutTypes = new SelectList(workoutTypes, nameof(WorkoutType.WorkoutTypeID), nameof(WorkoutType.Name)); }
			

			var muscleGroups = await _apiService.GetMuscleGroups();
			if (muscleGroups == null) { new SelectList(Enumerable.Empty<SelectListItem>()); }
			else{ MuscleGroups = new SelectList(muscleGroups, nameof(MuscleGroup.MuscleGroupID), nameof(MuscleGroup.Name)); }

			return Page();
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
				if (!string.IsNullOrEmpty(workoutAddDM.Link) && workoutAddDM.Link.Contains("https://www.youtube.com/watch?v="))
				{
					msworkout.Link = workoutAddDM.Link.Replace("https://www.youtube.com/watch?v=", "");
				}
				else
				{
					msworkout.Link = string.Empty;
				}

				var info = JsonConvert.SerializeObject(msworkout);

				var isTrue	= await _apiService.CreateMSWorkout(info);

				if (isTrue == true)
				{
					return RedirectToPage("/Fitness/Exercise/Exercises");
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
