using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TrackItWeb.Entities;
using TrackItWeb.Helpers;

namespace TrackItWeb.Pages.Nutrient
{
    public class AddRecipesModel : PageModel
    {
        [BindProperty]
        public Recipe? recipeAdd { get; set; }

        public async Task<IActionResult> OnPost()
        {
            recipeAdd.MemberID = User.GetMemberID();
            recipeAdd.Serve = 1;

            var info = JsonConvert.SerializeObject(recipeAdd);

            var client = new HttpClient();
            string url = "https://localhost:7004/api/Nutrient/CreateRecipe" + info;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync(url);

            if (responseMessage.IsSuccessStatusCode == true)
            {
                return RedirectToPage("/Nutrient/MyRecipes");
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
