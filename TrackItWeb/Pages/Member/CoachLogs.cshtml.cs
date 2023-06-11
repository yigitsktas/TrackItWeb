using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackItAPI.Entities;
using TrackItWeb.Helpers;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Member
{
    public class CoachLogsModel : PageModel
    {
		private readonly APIService _apiService;

		public CoachLogsModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public List<ChatLog> chatLogs { get; set; }

        public async Task<IActionResult> OnGet()
        {
			var response = await _apiService.GetChatLogs(User.GetMemberID());

			if (response != null)
			{
				chatLogs = response.OrderByDescending(x => x.CreatedDate).ToList();

				return Page();
			}
			else
			{
				return RedirectToPage("/Error");
			}
        }

		public async Task<IActionResult> OnPostDelete(Guid guid)
		{
			var isDeleted = await _apiService.DeleteChatLog(guid);

			if (isDeleted) { return RedirectToPage("/Member/CoachLogs"); }
			else { return RedirectToPage("/Error"); }
		}
	}
}
