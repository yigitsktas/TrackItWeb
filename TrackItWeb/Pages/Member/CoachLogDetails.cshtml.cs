using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackItAPI.Entities;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Member
{
    public class CoachLogDetailsModel : PageModel
    {
		private readonly APIService _apiService;

		public CoachLogDetailsModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public ChatLog MyModel { get; set; }

		public async Task<IActionResult> OnGet(Guid guid)
        {
			var response = await _apiService.GetChatLog(guid);

			if (response != null) { 
				
				MyModel = response;

				return Page();
			}
			else { return RedirectToPage("/Error"); }
        }
    }
}
