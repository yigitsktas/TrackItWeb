using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Text;
using TrackItWeb.DataModels;
using TrackItWeb.Entities;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Fitness.Exercise
{
    public class UpdateExericiseModel : PageModel
    {
		private readonly APIService _apiService;

		public UpdateExericiseModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public SelectList? WorkoutTypes { get; set; }
		public SelectList? MuscleGroups { get; set; }

		[BindProperty]
		public MemberSpecificWorkout? workoutUpdateDM { get; set; }

		public async Task<IActionResult> OnGet(Guid guid)
		{
			var workoutTypes = await _apiService.GetWorkoutTypes();
			if (workoutTypes == null) { new SelectList(Enumerable.Empty<SelectListItem>()); }
			else { WorkoutTypes = new SelectList(workoutTypes, nameof(WorkoutType.WorkoutTypeID), nameof(WorkoutType.Name)); }


			var muscleGroups = await _apiService.GetMuscleGroups();
			if (muscleGroups == null) { new SelectList(Enumerable.Empty<SelectListItem>()); }
			else { MuscleGroups = new SelectList(muscleGroups, nameof(MuscleGroup.MuscleGroupID), nameof(MuscleGroup.Name)); }

			var workout = await _apiService.GetMSWorkout(guid);

			workoutUpdateDM = workout;

			return Page();
		}

		public async Task<IActionResult> OnPost(MemberSpecificWorkout? workoutUpdateDM)
		{
			var info = JsonConvert.SerializeObject(workoutUpdateDM);

			StringContent content = new StringContent(info, Encoding.UTF8, "application/json");

			var isOk = await _apiService.UpdateMSWorkout(content);

			if (isOk) { return Redirect("/Fitness/Exercise/UpdateEXercise?guid=" + workoutUpdateDM.GUID); }
			else { return RedirectToPage("/Error"); }
		}
    }
}
