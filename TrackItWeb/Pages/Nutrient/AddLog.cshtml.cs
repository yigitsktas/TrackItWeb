using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TrackItWeb.Entities;

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
	}
}
