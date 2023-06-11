using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackItWeb.Helpers;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Fitness
{
    [Authorize]
    public class AnalyticsModel : PageModel
    {
    	private readonly APIService _apiService;

		public AnalyticsModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public async Task<JsonResult> OnGetFormatted(string Filter)
		{
			var result = await _apiService.GetWorkoutAnalytics(User.GetMemberID(), Filter);

			return new JsonResult(result);
		}
    }
}
