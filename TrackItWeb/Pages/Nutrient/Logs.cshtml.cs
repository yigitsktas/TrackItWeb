using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TrackItWeb.Entities;
using TrackItWeb.Helpers;

namespace TrackItWeb.Pages.Nutrient
{
    [Authorize]
    public class LogsModel : PageModel
    {
		public List<IndexVM>? Index { get; set; }

        public async Task<IActionResult> OnGet()
        {
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Nutrient/GetMemberNutrientLog/" + User.GetMemberID();
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				List<IndexVM> memberNutrientsLogs = new();

				var data = JsonConvert.DeserializeObject<List<MemberNutrient>>(await responseMessage.Content.ReadAsStringAsync());

				if (data != null)
				{
					foreach (var item in data)
					{
						IndexVM index = new();

						url = "https://localhost:7004/api/Nutrient/GetNutrientByID/" + item.NutrientID;
						HttpResponseMessage responseMessage1 = await client.GetAsync(url);

						if (responseMessage1.IsSuccessStatusCode == true)
						{
							var data1 = JsonConvert.DeserializeObject<TrackItWeb.Entities.Nutrient>(await responseMessage1.Content.ReadAsStringAsync());

							if (data1 != null)
							{
								double totalCalorie = 0;

								totalCalorie = (data1.Calorie / 100) * item.ServingSize;

								index.MemberNutrientID = item.NutrientID;
								index.NutrientName = data1.NutrientName;
								index.TotalCalorie = totalCalorie;
								index.CreatedDate = item.CreatedDate;

								memberNutrientsLogs.Add(index);	
							}
						}
					}

					Index = memberNutrientsLogs;
				}

				return Page();
			}
			else
			{
				return RedirectToPage("/Error");
			}
		}

		public class IndexVM
		{
			public int MemberNutrientID { get; set; }
			public string? NutrientName { get; set; }
			public DateTime CreatedDate { get; set; }
			public double TotalCalorie { get; set; }
		}
	}
}
