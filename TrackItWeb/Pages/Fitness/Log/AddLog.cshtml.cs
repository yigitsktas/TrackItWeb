using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackItWeb.Helpers;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Fitness.Log
{
	[Authorize]
	public class AddLogModel : PageModel
    {
		private readonly APIService _apiService;

		public AddLogModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public void OnGet()
        {

        }

		public async Task<IActionResult> OnGetMWLogDetails()
		{

			return Page();
		}

        public async Task<IActionResult> OnPostAddMWLog(string name, string notes)
        {
			string myNotes = "null";

			if (!string.IsNullOrEmpty(notes))
			{
				myNotes = notes;
			}

			var response = await _apiService.CreateMWorkoutLog(name, myNotes, User.GetMemberID());

			if (!string.IsNullOrEmpty(response))
			{
				return Redirect("~/Fitness/Log/UpdateLog?guid=" + response.Replace("\"", ""));
			}
			else
			{
				return RedirectToPage("/Error");
			}           
        }

		public async Task<IActionResult> OnPostMWLogStats()
		{
			return Page();
		}

	}
}
