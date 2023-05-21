using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net;
using TrackItWeb.Helpers;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Member
{
    [Authorize]
    public class ProfileModel : PageModel
    {
		private readonly APIService _apiService;

		public ProfileModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public Profile_DM? Index_VM { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Profile_DM model = new();

            var member = await _apiService.GetMember(User.GetMemberID());

            if (member != null)
            {
                model.Username = member.Username;
                model.EMail = member.EMail;
            }

			var memberMetric = await _apiService.GetMemberMetric(User.GetMemberID());

            if (memberMetric != null) 
            { 
                model.Height = memberMetric.Height;
                model.Weight = memberMetric.Weight;
                model.BMI = memberMetric.BMI;
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
