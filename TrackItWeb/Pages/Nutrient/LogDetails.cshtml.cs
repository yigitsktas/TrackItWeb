using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Nutrient
{
    public class LogDetailsModel : PageModel
    {
		private readonly APIService _apiService;

		public LogDetailsModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public void OnGet(int id)
        {





        }

		public class IndexVM
		{

		}
    }
}
