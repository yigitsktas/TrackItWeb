using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TrackItWeb.Entities;
using TrackItWeb.Helpers;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Nutrient
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

		public async Task<IActionResult> OnGet()
		{
			var data = await _apiService.GetMemberNutrientLogs(User.GetMemberID());

			var memberNutrients = data.OrderByDescending(x => x.CreatedDate).ToList();

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

		public async Task<IActionResult> OnPostDelete(int id)
		{
			var isDeleted = await _apiService.DeleteMemberNutrient(id);

			if (isDeleted){ return RedirectToPage("/Nutrient/Logs"); }
			else{ return RedirectToPage("/Error"); }
		}
	}
}

public class IndexVM
{
	public int MemberNutrientID { get; set; }
	public string? NutrientName { get; set; }
	public DateTime CreatedDate { get; set; }
	public double TotalCalorie { get; set; }
}
