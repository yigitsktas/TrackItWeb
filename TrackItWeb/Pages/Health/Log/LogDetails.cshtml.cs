using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using TrackItWeb.Entities;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Health.Log
{
	[Authorize]
	public class LogDetailsModel : PageModel
    {
		private readonly APIService _apiService;

		public LogDetailsModel(APIService apiService)
		{
			_apiService = apiService;
		}

		[BindProperty]
		public IndexVM MyModel { get; set; }

		public async Task<IActionResult> OnGet(Guid guid)
        {
			var memberNutrient = await _apiService.GetMemberNutrientLog(guid);

			if (memberNutrient != null)
			{
				IndexVM indexVM = new();

				indexVM.Notes = memberNutrient.Notes;
				indexVM.MemberNutrientID = memberNutrient.MemberNutrientID;
				indexVM.GUID = memberNutrient.GUID;
				indexVM.ServingSize = memberNutrient.ServingSize;
				indexVM.CreatedDate = memberNutrient.CreatedDate;

				var nutrient = await _apiService.GetNutrientByID(memberNutrient.NutrientID);

				if (nutrient != null)
				{
					indexVM.NutrientName = nutrient.NutrientName;
					indexVM.Brand = nutrient.Brand;
					indexVM.NutrientType = nutrient.NutrientType;
					indexVM.Calorie = (nutrient.Calorie / 100) * memberNutrient.ServingSize;
					indexVM.TotalFat = (nutrient.TotalFat / 100) * memberNutrient.ServingSize;
					indexVM.TotalCarb = (nutrient.TotalCarb / 100) * memberNutrient.ServingSize;
					indexVM.TotalProtein = (nutrient.TotalProtein / 100) * memberNutrient.ServingSize;
					indexVM.TotalSugar = (nutrient.TotalSugar / 100) * memberNutrient.ServingSize;
				}

				MyModel = indexVM;

				return Page();
			}

			else { return RedirectToPage("/Error"); }
		}

		public async Task<IActionResult> OnPost(IndexVM MyModel)
		{
			MemberNutrient mn = new();

			mn.MemberNutrientID = MyModel.MemberNutrientID;
			mn.Notes = MyModel.Notes;
			mn.ServingSize = MyModel.ServingSize;

			var info = JsonConvert.SerializeObject(mn);

			StringContent content = new StringContent(info, Encoding.UTF8, "application/json");

			var isOk = await _apiService.UpdateMemberNutrient(content);

			if (isOk)
			{
				return Redirect("~/Health/Log/LogDetails?guid=" + MyModel.GUID);
			}
			else
			{
				return Page();
			}
		}

		public class IndexVM
		{
			public int MemberNutrientID { get; set; }
			public Guid GUID { get; set; }
			public double ServingSize { get; set; }
			public string? Notes { get; set; }
			public string? NutrientName { get; set; }
			public string? Brand { get; set; }
			public int NutrientType { get; set; }
			public double Calorie { get; set; }
			public double TotalFat { get; set; }
			public double TotalCarb { get; set; }
			public double TotalProtein { get; set; }
			public double TotalSugar { get; set; }
			public DateTime CreatedDate { get; set; }
		}
	}
}
