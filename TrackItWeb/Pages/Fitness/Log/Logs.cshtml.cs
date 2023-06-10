using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackItWeb.Entities;
using TrackItWeb.Helpers;
using TrackItWeb.Services;

namespace TrackItWeb.Pages.Fitness.Log
{
	[Authorize]
	public class LogsModel : PageModel
	{
		private readonly APIService _apiService;

		public LogsModel(APIService apiService)
		{
			_apiService = apiService;
		}

		public List<IndexVM>? Index { get; set; }

		public async Task<IActionResult> OnGet(string searchString, string orderBy)
		{
			var data = new List<MemberWorkoutLog>();

			data = await _apiService.GetMemberWorkoutLogs(User.GetMemberID());

			var memberWorkoutLogs = data.ToList();

			if (memberWorkoutLogs != null)
			{
				List<IndexVM> indexList = new();

				foreach (var item in memberWorkoutLogs)
				{
					IndexVM index = new();

					index.MemberWorkoutLogID = item.MemberWorkoutID;
					index.GUID = item.GUID;
					index.WorkoutName = item.MemberWorkoutName;
					index.isDone = item.isDone;
					index.CreatedDate = item.CreatedDate;

					indexList.Add(index);
				}

				Index = indexList;

				return Page();
			}
			else
			{
				return RedirectToPage("/Error");
			}
		}

		public async Task<IActionResult> OnPostDelete(Guid guid)
		{
			var isDeleted = await _apiService.DeleteMWorkoutLog(guid);

			if (isDeleted) { return RedirectToPage("/Fitness/Log/Logs"); }
			else { return RedirectToPage("/Error"); }
		}
	}
	public class IndexVM
	{
		public int MemberWorkoutLogID { get; set; }
		public Guid GUID { get; set; }
		public string? WorkoutName { get; set; }
		public bool isDone { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}

