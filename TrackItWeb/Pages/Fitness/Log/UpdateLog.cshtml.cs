using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackItWeb.Entities;
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

		public async Task<IActionResult> OnGet(Guid guid)
		{
			var response = await _apiService.GetMemberWorkoutLog(guid);

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

		public async Task<IActionResult> OnPostUpdate(int id)
		{
			return Page();
		}

		public IActionResult OnGetLoadLogStats(int id)
		{
			return Page();
		}

		public IActionResult OnPostAddLogStats()
		{
			return Page();
		}
	}
}
