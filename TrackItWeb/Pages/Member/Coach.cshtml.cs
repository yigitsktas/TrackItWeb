using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using TrackItAPI.Entities;
using TrackItWeb.Helpers;
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
			TempData["prompt"] = prompt;

			if (!string.IsNullOrEmpty(prompt))
			{
				var answer = await _apiService.GetAnswer(prompt);

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

		public async Task<IActionResult> OnPostAddLog(string result)
		{
			if (!string.IsNullOrEmpty(result))
			{
				ChatLog chatLog = new();

				chatLog.Answer = result;	
				chatLog.Prompt = TempData.Peek("prompt").ToString(); 
				chatLog.MemberID = User.GetMemberID();
				chatLog.CreatedDate = DateTime.Now;

				var info = JsonConvert.SerializeObject(chatLog);

				StringContent content = new StringContent(info, Encoding.UTF8, "application/json");

				var isOk = await _apiService.CreateChatLog(content);

				if (isOk)
				{
					return RedirectToPage("/Home/Index");
				}
				else
				{
					return RedirectToPage("/Error");
				}
			}
			else
			{
				return RedirectToPage("/Error");
			}
		}
	}
}
