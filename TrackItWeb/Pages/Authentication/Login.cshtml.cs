using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Security.Claims;
using TrackItWeb.Entities;

namespace TrackItWeb.Pages.Authentication
{
    public class LoginModel : PageModel
    {
		public IActionResult OnGet()
		{
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(string username, string password)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Member/Login/" + username + "/" + password;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage != null)
			{
				if (responseMessage.IsSuccessStatusCode)
				{
					var member = JsonConvert.DeserializeObject<TrackItWeb.Entities.Member>(await responseMessage.Content.ReadAsStringAsync());
					
					if (member != null)
					{
						var scheme = CookieAuthenticationDefaults.AuthenticationScheme;

						var MyClaim = new ClaimsPrincipal(
						new ClaimsIdentity(
						new List<Claim>
													{
							new Claim(ClaimTypes.Name, member.Username.ToString()),
							new Claim(ClaimTypes.Sid, member.MemberID.ToString()),
													},
													scheme
											)
										);
						var cookieOptions = new CookieOptions();
						cookieOptions.Expires = DateTime.Now.AddDays(1);

						await HttpContext.SignInAsync(scheme, MyClaim);

						return Redirect("/Home/Index");
					}
                    else
                    {
                        return Redirect("/Error");
                    }
                }
				else
				{
					return Redirect("/Error");
				}
			}
			else
			{
				return Redirect("/Error");
			}
		}

        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Home/Index");
        }
    }
}
