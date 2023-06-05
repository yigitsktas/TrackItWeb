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

		public async Task<IActionResult> OnGet(string searchString, string orderBy)
		{
			var data = new List<MemberNutrient>();

			if (!string.IsNullOrEmpty(searchString) || !string.IsNullOrEmpty(orderBy))
			{
				data = await _apiService.GetMemberNutrientFilteredLogs(User.GetMemberID(), searchString, orderBy);
			}
			else
			{
				var data1 = await _apiService.GetMemberNutrientLogs(User.GetMemberID());
				data = data1.OrderByDescending(x => x.CreatedDate).ToList();
			}

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

				Index = memberNutrientsLogs;
				
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

