using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TrackItWeb.Pages.Workout
{
    [Authorize]
    public class AnalyticsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}