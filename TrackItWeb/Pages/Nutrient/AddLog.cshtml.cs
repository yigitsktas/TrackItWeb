using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TrackItWeb.DataModels;
using TrackItWeb.Entities;
using TrackItWeb.Helpers;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Nutrient
{
	public class AddLogModel : PageModel
	{
		private readonly APIService _apiService;

		public AddLogModel(APIService apiService) 
		{ 
			_apiService = apiService;
		}

		public SelectList? Nutrients { get; set; }

		public async Task<IActionResult> OnGet()
		{
			var nutrients = await _apiService.GetNutrients();

			if (nutrients != null)
			{
				Nutrients = new SelectList(nutrients, nameof(TrackItWeb.Entities.Nutrient.NutrientID), nameof(TrackItWeb.Entities.Nutrient.NutrientName));

				return Page();
			}

			else
			{
				return RedirectToPage("/Error");
			}
		}
		
		[BindProperty]
		public AddNutrientLogDM? addLogDM { get; set; } 

        public async Task<IActionResult> OnPost()
		{
			MemberNutrient memberNutrient = new();

			memberNutrient.MemberID = User.GetMemberID();
			memberNutrient.NutrientID = addLogDM.NutrientID;
			memberNutrient.Notes = addLogDM.Notes;
			memberNutrient.ServingSize = addLogDM.Portions;
			memberNutrient.ServingType = addLogDM.ServingType;
			memberNutrient.CreatedDate = DateTime.Now;

			var info = JsonConvert.SerializeObject(memberNutrient);

			var isTrue = await _apiService.CreateMemberNutrient(info);

            if (isTrue)
            {
                return RedirectToPage("/Nutrient/Logs");
            }
            else
            {
                return RedirectToPage("/Error");
            }
		}
    }
}
