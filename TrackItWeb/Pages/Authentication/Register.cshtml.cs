using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Security.Claims;

namespace TrackItWeb.Pages.Authentication
{
    public class RegisterModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost(string email, string username, string password)
        {
            if (username != null || password != null || email != null)
            {
                TrackItWeb.Entities.Member member = new();

                member.Username = username;
                member.Password = password;
                member.EMail = email;
                member.Gender = 0;
                member.BirthYear = DateTime.Now;
                member.UpdatedDate = DateTime.Now;
                member.CreatedDate = DateTime.Now;

                var info = JsonConvert.SerializeObject(member);

                var client = new HttpClient();
                string url = "https://localhost:7004/api/Member/CreateUser/" + info;
                client.BaseAddress = new Uri(url);
                HttpResponseMessage responseMessage = await client.GetAsync(url);

                if (responseMessage.IsSuccessStatusCode)
                { 
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
    }
}
