using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TrackItWeb.Pages.Nutrient
{
    public class AddRecipesModel : PageModel
    {
        public async Task<IActionResult> OnPost()
        {

            return RedirectToPage("/MyRecipes");
        }
    }
}
