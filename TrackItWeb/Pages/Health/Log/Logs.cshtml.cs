using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TrackItWeb.Entities;
using TrackItWeb.Helpers;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Health.Log
{
	[Authorize]
	public class LogsModel : PageModel
	{
		private readonly APIService _apiService;

		public LogsModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public List<IndexVM>? Index { get; set; }
		public Dictionary<string, object> Parameters { get; set; }

		public async Task<IActionResult> OnGet(string searchString="", string orderBy="")
		{
			var data = new List<MemberNutrient>();

			data = await _apiService.GetMemberNutrientLogs(User.GetMemberID());
			
			Dictionary<string, object> map = new()
			{
				{"SearchString", searchString},
				{"OrderBy", orderBy}
			};

			Parameters = map;

			var memberNutrients = data.ToList();

			if (memberNutrients != null)
			{
				List<IndexVM> memberNutrientsLogs = new();

				foreach (var item in memberNutrients)
				{
					IndexVM index = new();

					var nutrient = await _apiService.GetNutrientByID(item.NutrientID);

					if (nutrient != null)
					{
						double totalCalorie = 0;

						totalCalorie = (nutrient.Calorie / 100) * item.ServingSize;

						index.MemberNutrientID = item.MemberNutrientID;
						index.GUID = item.GUID;
						index.NutrientName = nutrient.NutrientName;
						index.TotalCalorie = totalCalorie;
						index.CreatedDate = item.CreatedDate;

						memberNutrientsLogs.Add(index);
					}
				}

				if (!string.IsNullOrEmpty(searchString))
				{
					Index = memberNutrientsLogs.Where(x => x.NutrientName.ToLower().Contains(searchString)).ToList();
				}
				else if (!string.IsNullOrEmpty(orderBy))
				{
					if (orderBy == "date-desc")
					{
						Index = memberNutrientsLogs.OrderByDescending(x => x.CreatedDate).ToList();
					}
					else
					{
						Index = memberNutrientsLogs.OrderBy(x => x.CreatedDate).ToList();
					}
				}
				else
				{
					Index = memberNutrientsLogs.OrderByDescending(x => x.CreatedDate).ToList();
				}
				
				return Page();
			}
			else
			{
				return RedirectToPage("/Error");
			}
		}

		public async Task<IActionResult> OnPostDelete(Guid guid)
		{
			var isDeleted = await _apiService.DeleteMemberNutrient(guid);

			if (isDeleted){ return RedirectToPage("/Health/Log/Logs"); }
			else{ return RedirectToPage("/Error"); }
		}
	}
	
	public class IndexVM
	{
		public int MemberNutrientID { get; set; }
		public Guid GUID { get; set; }
		public string? NutrientName { get; set; }
		public DateTime CreatedDate { get; set; }
		public double TotalCalorie { get; set; }
	}
}

