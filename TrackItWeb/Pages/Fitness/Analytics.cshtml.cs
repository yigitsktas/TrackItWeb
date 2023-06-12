using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
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

			List<Graph_DM> response = new();
			foreach (var item in result)
			{
				List<string> myList = new();
				Graph_DM graph = new Graph_DM();

				foreach (var b in item.Logs)
				{
					myList.Add(b.Reps + " , " + b.Weight);
				}

				graph.name = item.Name;
				graph.data = myList;	

				response.Add(graph);
			}
			
			var ab = JsonConvert.SerializeObject(response);

			return new JsonResult(response);
		}

		public class Graph_DM
		{
			public string? name { get; set; }
			public List<string>? data { get; set; }
		}
    }
}
