using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net;
using TrackItWeb.Helpers;

namespace TrackItWeb.Pages.Member
{
    [Authorize]
    public class ProfileModel : PageModel
    {

        public Profile_DM? Index_VM { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Profile_DM model = new();

			var client = new HttpClient();
			string url = "https://localhost:7004/api/Member/GetMember/" + User.GetMemberID();

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

            if (responseMessage.IsSuccessStatusCode == true) 
            {
				var member = JsonConvert.DeserializeObject<TrackItWeb.Entities.Member>(await responseMessage.Content.ReadAsStringAsync());

                if (member != null)
                {
                    model.Username = member.Username;
                    model.EMail = member.EMail;
                }
			}
			else 
            {
				return Page();
			}

			url = "https://localhost:7004/api/Member/GetMemberMetric/" + User.GetMemberID();
			HttpResponseMessage responseMessage1 = await client.GetAsync(url);
            if (responseMessage1.IsSuccessStatusCode == true)
            {
				var memberMetric = JsonConvert.DeserializeObject<TrackItWeb.Entities.MemberMetric>(await responseMessage.Content.ReadAsStringAsync());
                    
                if (memberMetric != null) 
                { 
                    model.Height = memberMetric.Height;
                    model.Weight = memberMetric.Weight;
                    model.BMI = memberMetric.BMI;
                }
			}
			else
			{
				return Page();
			}

            Index_VM = model;

			return Page();
		}

        public async Task<IActionResult> OnPostUpdate()
        {

            return Page();
        }

    }

    public class Profile_DM
    {
        public string? Username { get; set; }
        public string? EMail { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double BMI { get; set; }
    }
}
