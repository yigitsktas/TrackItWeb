using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackItWeb.Helpers;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Nutrient
{
    [Authorize]
    public class AnalyticsModel : PageModel
    {
		private readonly APIService _apiService;

		public AnalyticsModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public string Date { get; set; }	
		public string Info { get; set; }	

		public async Task<JsonResult> OnGetFormatted(string Date, string Info)
		{
			var result = await _apiService.GetNutrientAnalytics(User.GetMemberID(), Date, Info);

			return new JsonResult(result);
		}
	}
}
