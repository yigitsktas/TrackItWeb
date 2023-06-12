using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using TrackItAPI.Entities;
using TrackItWeb.DataModels;
using TrackItWeb.Entities;
using TrackItWeb.Helpers;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Fitness.Log
{
	public class UpdateLogModel : PageModel
	{
		private readonly APIService _apiService;

		public UpdateLogModel(APIService apiService)
		{
			_apiService = apiService;
		}

		[BindProperty]
		public MemberWorkoutLog MyResult { get; set; }
		public SelectList? YourWorkouts { get; set; }
		public SelectList? OurWorkouts { get; set; }

		public async Task<IActionResult> OnGet(Guid guid)
		{
			var response = await _apiService.GetMemberWorkoutLog(guid);
			var yourWorkouts = await _apiService.GetMSWorkouts(User.GetMemberID());
			var ourWorkouts = await _apiService.GetWorkouts();

			if (yourWorkouts != null || ourWorkouts != null)
			{
				OurWorkouts = new SelectList(ourWorkouts, nameof(Entities.Workout.WorkoutID), nameof(Entities.Workout.WorkoutName));

				YourWorkouts = new SelectList(yourWorkouts, nameof(Entities.MemberSpecificWorkout.MemberSpecificWorkoutID), nameof(Entities.MemberSpecificWorkout.WorkoutName));
			}
			if (response != null)
			{
				MyResult = response;
				return Page();
			}
			else
			{
				return RedirectToPage("/Error");
			}
		}

		public async Task<IActionResult> OnPostUpdate(MemberWorkoutLog MyResult)
		{
			var info = JsonConvert.SerializeObject(MyResult);

			StringContent content = new StringContent(info, Encoding.UTF8, "application/json");

			var isOk = await _apiService.UpdateMWorkoutLog(content);

			if (isOk)
			{
				return Redirect("~/Fitness/Log/UpdateLog?guid=" + MyResult.GUID);
			}
			else
			{
				return Page();
			}
		}

		public async Task<ActionResult> OnGetLoadLogStats(int id)
		{
			var response = await _apiService.GetMemberWorkoutLogStat(User.GetMemberID(), id);

			string html = "<div class='row'><div class='col-3'><label class='form-label text-dark float-start fw-bold'>workout name.</label></div><div class='col-3'><label class='form-label text-dark float-start fw-bold'>muscle.</label></div><div class='col-2'><label class='form-label text-dark float-start fw-bold'>reps.</label></div><div class='col-2'><label class='form-label text-dark float-start fw-bold'>weight.</label></div><div class='col-2'><label class='form-label text-dark float-end fw-bold'></label></div></div><hr class='mt-1 mb-1' />";

			if (response != null)
			{
				foreach (var item in response)
				{
					html += "<div class='row mt-2'>";

					html += "<div class='col-3 mt-1'>";
					html += "<label class='form-label text-dark float-start fw-bold'>" + item.WorkoutName.ToLower() + "</label>";
					html += "</div>";

					html += "<div class='col-3 mt-1'>";
					html += "<label class='form-label text-dark float-start fw-bold'>" + item.MuscleGroup.ToLower() + "</label>";
					html += "</div>";

					html += "<div class='col-2 mt-1'>";
					html += "<label class='form-label text-dark float-start fw-bold'>" + item.Reps + "x</label>";
					html += "</div>";

					html += "<div class='col-2 mt-1'>";
					html += "<label class='form-label text-dark float-start fw-bold'>" + item.Weight + " kg</label>";
					html += "</div>";

					html += "<div class='col-2'>";
					html += "<button id='btn_sbmt' class='btn btn-outline-danger border-1 border-dark btn-sm rounded-0 fw-bold float-end' style='width: 30px' onclick='DeleteStat(" + item.MemberStatisticID + ")'>X</button>";
					html += "</div>";

					html += "</div>";

					html += "<hr class='mt-2 mb-2' />";
				}

				var tt = html;

				return Content(tt);
			}
			else
			{
				return Content("error");
			}
		}

		public async Task<ActionResult> OnPostAddLogStats([FromForm] MemberWorkoutLogStat model)
		{
			if (ModelState.IsValid)
			{
				var info = JsonConvert.SerializeObject(model);

				StringContent content = new StringContent(info, Encoding.UTF8, "application/json");

				var isOk = await _apiService.CreateWorkoutLogStat(content);

				if (isOk) { return Content("success"); }
				else { return Content("error"); }
			}
			else
			{
				return Content("error");
			}
		}

		public async Task<ActionResult> OnPostDeleteStat(int id)
		{
			if (id > 0)
			{
				var isOk = await _apiService.DeleteMemberWorkoutLogStat(User.GetMemberID(), id);

				if (isOk) { return Content("success"); }
				else { return Content("error"); }
			}
			else
			{
				return Content("error");
			}
		}
	}
}
