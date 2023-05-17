using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TrackItWeb.DataModels;
using TrackItWeb.Entities;
using TrackItWeb.Helpers;

namespace TrackItWeb.Pages.Nutrient
{
	public class AddLogModel : PageModel
	{
		public SelectList? Nutrients { get; set; }

		public async Task<IActionResult> OnGet()
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Nutrient/GetNutrients";
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var muscleGroups = JsonConvert.DeserializeObject<List<TrackItWeb.Entities.Nutrient>>(await responseMessage.Content.ReadAsStringAsync());

				Nutrients = new SelectList(muscleGroups, nameof(TrackItWeb.Entities.Nutrient.NutrientID), nameof(TrackItWeb.Entities.Nutrient.NutrientName));

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

			var info = JsonConvert.SerializeObject(memberNutrient);

            var client = new HttpClient();
            string url = "https://localhost:7004/api/Nutrient/CreateMemberNutrient" + info + string.Empty;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync(url);

            if (responseMessage.IsSuccessStatusCode == true)
            {
                return RedirectToPage("/Nutrient/Log");
            }
            else
            {
                return RedirectToPage("/Error");
            }
		}
    }
}
