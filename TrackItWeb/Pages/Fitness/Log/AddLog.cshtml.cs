using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TrackItWeb.Pages.Fitness.Log
{
	[Authorize]
	public class AddLogModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
