using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Member
{
    public class CoachModel : PageModel
    {
		private readonly APIService _apiService;

		public CoachModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public string Answer { get; set; }

		public async Task<IActionResult> OnGet()
		{
			return Page();
		}

		public async Task<IActionResult> OnPost(string prompt)
        {
			if (!string.IsNullOrEmpty(prompt))
			{
				var answer = await  _apiService.GetAnswer(prompt);

				if (answer != null)
				{
					Answer = answer;

					Answer = Answer.Replace("\n\n", "<br>");

					return Page();
				}
				else
				{
					return RedirectToPage("/Error");
				}
			}
			else
			{
				ModelState.AddModelError("NoPrompt", "please enter something!");
				return Page();
			}
        }
    }
}
