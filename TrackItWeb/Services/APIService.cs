using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TrackItAPI.Entities;
using TrackItWeb.DataModels;
using TrackItWeb.Entities;
using TrackItWeb.Helpers;

namespace TrackItWeb.Services
{
	public class APIService
	{
		#region Nutrient

		public async Task<List<Recipe>> GetRecipes()
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Nutrient/GetRecipes";

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var recipe = JsonConvert.DeserializeObject<List<Recipe>>(await responseMessage.Content.ReadAsStringAsync());

				if (recipe != null)
				{
					return recipe;
				}
				else
				{
					return new List<Recipe>();
				}
			}
			else
			{
				return new List<Recipe>();
			}
		}

		public async Task<List<Recipe>> GetMemberRecipes(int id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Nutrient/GetMemberRecipes/" + id;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var recipes = JsonConvert.DeserializeObject<List<Recipe>>(await responseMessage.Content.ReadAsStringAsync());

				if (recipes != null)
				{
					return recipes;
				}
				else
				{
					return new List<Recipe>();
				}
			}
			else
			{
				return new List<Recipe>();
			}
		}

		public async Task<bool> CreateRecipe(StringContent info)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Nutrient/CreateRecipe/";
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.PostAsync(url, info);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteRecipe(Guid id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Nutrient/DeleteRecipe/" + id;
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<List<Nutrient>> GetNutrients()
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Nutrient/GetNutrients";
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var muscleGroups = JsonConvert.DeserializeObject<List<TrackItWeb.Entities.Nutrient>>(await responseMessage.Content.ReadAsStringAsync());

				if (muscleGroups != null)
				{
					return muscleGroups;
				}
				else
				{
					return new List<Nutrient>();
				}
			}
			else
			{
				return new List<Nutrient>();
			}
		}

		public async Task<bool> CreateMemberNutrient(StringContent info)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Nutrient/CreateMemberNutrient";
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.PostAsync(url, info);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteMemberNutrient(Guid id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Nutrient/DeleteMemberNutrient/" + id;
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateMemberNutrient(StringContent info)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Nutrient/UpdateMemberNutrient";
			HttpResponseMessage responseMessage = await client.PostAsync(url, info);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<MemberNutrient> GetMemberNutrientLog(Guid id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Nutrient/GetMemberNutrientLog/" + id;
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var memberNutrient = JsonConvert.DeserializeObject<MemberNutrient>(await responseMessage.Content.ReadAsStringAsync());

				if (memberNutrient != null)
				{
					return memberNutrient;
				}
				else
				{
					return new MemberNutrient();
				}
			}
			else
			{
				return new MemberNutrient();
			}
		}

		public async Task<List<MemberNutrient>> GetMemberNutrientLogs(int id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Nutrient/GetMemberNutrientLogs/" + id;
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var memberNutrients = JsonConvert.DeserializeObject<List<MemberNutrient>>(await responseMessage.Content.ReadAsStringAsync());

				if (memberNutrients != null)
				{
					return memberNutrients;
				}
				else
				{
					return new List<MemberNutrient>();
				}
			}
			else
			{
				return new List<MemberNutrient>();
			}
		}

		public async Task<Nutrient> GetNutrientByID(int id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Nutrient/GetNutrientByID/" + id;
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var nutrient = JsonConvert.DeserializeObject<Nutrient>(await responseMessage.Content.ReadAsStringAsync());

				if (nutrient != null)
				{
					return nutrient;
				}
				else
				{
					return new Nutrient();
				}
			}
			else
			{
				return new Nutrient();
			}
		}

		public async Task<Recipe> GetRecipe(Guid id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Nutrient/GetRecipe/" + id;
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var recipe = JsonConvert.DeserializeObject<Recipe>(await responseMessage.Content.ReadAsStringAsync());

				if (recipe != null)
				{
					return recipe;
				}
				else
				{
					return new Recipe();
				}
			}
			else
			{
				return new Recipe();
			}
		}

		public async Task<bool> UpdateRecipe(StringContent info)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Nutrient/UpdateRecipe";
			HttpResponseMessage responseMessage = await client.PostAsync(url, info);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<List<Recipe>> GetRandomRecipes()
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Nutrient/GetRandomRecipe";

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var recipe = JsonConvert.DeserializeObject<List<Recipe>>(await responseMessage.Content.ReadAsStringAsync());

				if (recipe != null)
				{
					return recipe;
				}
				else
				{
					return new List<Recipe>();
				}
			}
			else
			{
				return new List<Recipe>();
			}
		}

		public async Task<List<NAnalytics>> GetNutrientAnalytics(int id, string date, string info)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Nutrient/GetNutrientAnalytics/" + id + "/" + info + "/" + date;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var logs = JsonConvert.DeserializeObject<List<NAnalytics>>(await responseMessage.Content.ReadAsStringAsync());

				if (logs != null)
				{
					return logs;
				}
				else
				{
					return new List<NAnalytics>();
				}
			}
			else
			{
				return new List<NAnalytics>();
			}
		}

		#endregion


		#region Workout

		public async Task<List<MemberSpecificWorkout>> GetMSWorkouts(int id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/GetMSWorkouts/" + id;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var workouts = JsonConvert.DeserializeObject<List<TrackItWeb.Entities.MemberSpecificWorkout>>(await responseMessage.Content.ReadAsStringAsync());

				if (workouts != null)
				{
					return workouts;
				}
				else
				{
					return new List<MemberSpecificWorkout>();
				}
			}
			else
			{
				return new List<MemberSpecificWorkout>();
			}
		}

		public async Task<bool> CreateMSWorkout(string info)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/CreateMSWorkout/" + info;
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateMSWorkout(StringContent info)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/UpdateMSWorkout";
			HttpResponseMessage responseMessage = await client.PostAsync(url, info);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteMSWorkout(Guid id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/DeleteMSWorkout/" + id;
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<MemberSpecificWorkout> GetMSWorkout(Guid id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/GetMSWorkout/" + id;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var workout = JsonConvert.DeserializeObject<TrackItWeb.Entities.MemberSpecificWorkout>(await responseMessage.Content.ReadAsStringAsync());
				if (workout != null)
				{
					return workout;
				}
				else
				{
					return new MemberSpecificWorkout();
				}
			}
			else
			{
				return new MemberSpecificWorkout();
			}
		}

		public async Task<Workout> GetWorkout(Guid id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/GetWorkout/" + id;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var workout = JsonConvert.DeserializeObject<TrackItWeb.Entities.Workout>(await responseMessage.Content.ReadAsStringAsync());
				if (workout != null)
				{
					return workout;
				}
				else
				{
					return new Workout();
				}
			}
			else
			{
				return new Workout();
			}
		}

		public async Task<List<Workout>> GetWorkouts()
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/GetWorkouts/";

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var workouts = JsonConvert.DeserializeObject<List<Workout>>(await responseMessage.Content.ReadAsStringAsync());
				if (workouts != null)
				{
					return workouts;
				}
				else
				{
					return new List<Workout>();
				}
			}
			else
			{
				return new List<Workout>();
			}
		}

		public async Task<WorkoutType> GetWorkoutType(int id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/GetWorkoutType/" + id;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var workoutType = JsonConvert.DeserializeObject<TrackItWeb.Entities.WorkoutType>(await responseMessage.Content.ReadAsStringAsync());

				if (workoutType != null)
				{
					return workoutType;
				}
				else
				{
					return new WorkoutType();
				}
			}
			else
			{
				return new WorkoutType();
			}
		}

		public async Task<MuscleGroup> GetMuscleGroup(int id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/GetMuscleGroup/" + id;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var muscleGroup = JsonConvert.DeserializeObject<TrackItWeb.Entities.MuscleGroup>(await responseMessage.Content.ReadAsStringAsync());

				if (muscleGroup != null)
				{
					return muscleGroup;
				}
				else
				{
					return new MuscleGroup();
				}
			}
			else
			{
				return new MuscleGroup();
			}
		}

		public async Task<List<WorkoutType>> GetWorkoutTypes()
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/GetWorkoutTypes/";

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var workoutTypes = JsonConvert.DeserializeObject<List<WorkoutType>>(await responseMessage.Content.ReadAsStringAsync());

				if (workoutTypes != null)
				{
					return workoutTypes;
				}
				else
				{
					return new List<WorkoutType>();
				}
			}
			else
			{
				return new List<WorkoutType>();
			}
		}

		public async Task<List<MuscleGroup>> GetMuscleGroups()
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/GetMuscleGroups/";

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var muscleGroups = JsonConvert.DeserializeObject<List<MuscleGroup>>(await responseMessage.Content.ReadAsStringAsync());

				if (muscleGroups != null)
				{
					return muscleGroups;
				}
				else
				{
					return new List<MuscleGroup>();
				}
			}
			else
			{
				return new List<MuscleGroup>();
			}
		}

		public async Task<List<Workout>> GetRandomWorkouts()
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/GetRandomWorkout";

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var workouts = JsonConvert.DeserializeObject<List<Workout>>(await responseMessage.Content.ReadAsStringAsync());
				if (workouts != null)
				{
					return workouts;
				}
				else
				{
					return new List<Workout>();
				}
			}
			else
			{
				return new List<Workout>();
			}
		}

		public async Task<string> CreateMWorkoutLog(string name, string notes, int id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/CreateMWorkoutLog/" + name + "/" + notes + "/" + id;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var response = await responseMessage.Content.ReadAsStringAsync();

				return response;
			}
			else
			{
				return "";
			}
		}

		public async Task<bool> UpdateMWorkoutLog(StringContent info)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/UpdateWorkoutLog";
			HttpResponseMessage responseMessage = await client.PostAsync(url, info);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteMWorkoutLog(Guid id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/DeleteMWorkouLog/" + id;
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<MemberWorkoutLog> GetMemberWorkoutLog(Guid id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/GetMWorkoutLog/" + id;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var workoutLog = JsonConvert.DeserializeObject<TrackItWeb.Entities.MemberWorkoutLog>(await responseMessage.Content.ReadAsStringAsync());

				if (workoutLog != null)
				{
					return workoutLog;
				}
				else
				{
					return new MemberWorkoutLog();
				}
			}
			else
			{
				return new MemberWorkoutLog();
			}
		}

		public async Task<List<MemberWorkoutLog>> GetMemberWorkoutLogs(int id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/GetMWorkoutLogs/" + id;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var mWorkoutLogs = JsonConvert.DeserializeObject<List<MemberWorkoutLog>>(await responseMessage.Content.ReadAsStringAsync());

				if (mWorkoutLogs != null)
				{
					return mWorkoutLogs;
				}
				else
				{
					return new List<MemberWorkoutLog>();
				}
			}
			else
			{
				return new List<MemberWorkoutLog>();
			}
		}

		public async Task<bool> CreateWorkoutLogStat(StringContent info)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/CreateWorkoutLogStat";
			HttpResponseMessage responseMessage = await client.PostAsync(url, info);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<List<MemberWorkoutLogStat_DM>> GetMemberWorkoutLogStat(int memberId, int id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/GetMemberWorkoutLogStat/" + memberId + "/" + id;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var mWorkoutLogs = JsonConvert.DeserializeObject<List<MemberWorkoutLogStat_DM>>(await responseMessage.Content.ReadAsStringAsync());

				if (mWorkoutLogs != null)
				{
					return mWorkoutLogs;
				}
				else
				{
					return new List<MemberWorkoutLogStat_DM>();
				}
			}
			else
			{
				return new List<MemberWorkoutLogStat_DM>();
			}
		}

		public async Task<bool> DeleteMemberWorkoutLogStat(int memberId, int id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/DeleteMemberWorkoutLogStat/" + memberId + "/" + id;
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<List<WorkoutAnalytics>> GetWorkoutAnalytics(int id, string date)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Workout/GetWorkoutAnalytics/" + id + "/" + date;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var mWorkoutLogs = JsonConvert.DeserializeObject<List<WorkoutAnalytics>>(await responseMessage.Content.ReadAsStringAsync());

				if (mWorkoutLogs != null)
				{
					return mWorkoutLogs;
				}
				else
				{
					return new List<WorkoutAnalytics>();
				}
			}
			else
			{
				return new List<WorkoutAnalytics>();
			}
		}

		#endregion


		#region Authentication

		public async Task<Member> CreateUser(StringContent info)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Member/CreateUser/";
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.PostAsync(url, info);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var member = JsonConvert.DeserializeObject<Member>(await responseMessage.Content.ReadAsStringAsync());

				if (member != null)
				{
					return member;
				}
				else
				{
					return new Member();
				}
			}
			else
			{
				return new Member();
			}
		}

		public async Task<bool> Login(string username, string password)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Member/Login/" + username + "/" + password;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			return responseMessage.IsSuccessStatusCode;
		}

		#endregion


		#region Member

		public async Task<Member> GetMember(int id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Member/GetMember/" + id;
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var member = JsonConvert.DeserializeObject<TrackItWeb.Entities.Member>(await responseMessage.Content.ReadAsStringAsync());

				if (member != null)
				{
					return member;
				}
				else
				{
					return new TrackItWeb.Entities.Member();
				}
			}
			else
			{
				return new TrackItWeb.Entities.Member();
			}
		}

		public async Task<MemberMetric> GetMemberMetric(int id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Member/GetMemberMetric/" + id;
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var memberMetric = JsonConvert.DeserializeObject<TrackItWeb.Entities.MemberMetric>(await responseMessage.Content.ReadAsStringAsync());

				if (memberMetric != null)
				{
					return memberMetric;
				}
				else
				{
					return new TrackItWeb.Entities.MemberMetric();
				}
			}
			else
			{
				return new TrackItWeb.Entities.MemberMetric();
			}
		}

		public async Task<bool> UpdateMember(string info)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Member/UpdateMember/" + info;
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<bool> CreateChatLog(StringContent info)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Member/CreateChatLog";
			HttpResponseMessage responseMessage = await client.PostAsync(url, info);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<List<ChatLog>> GetChatLogs(int id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Member/GetChatLogs/" + id;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var chatLogs = JsonConvert.DeserializeObject<List<ChatLog>>(await responseMessage.Content.ReadAsStringAsync());

				if (chatLogs != null)
				{
					return chatLogs;
				}
				else
				{
					return new List<ChatLog>();
				}
			}
			else
			{
				return new List<ChatLog>();
			}
		}

		public async Task<ChatLog> GetChatLog(Guid id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Member/GetChatLog/" + id;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var chatLog = JsonConvert.DeserializeObject<ChatLog>(await responseMessage.Content.ReadAsStringAsync());

				if (chatLog != null)
				{
					return chatLog;
				}
				else
				{
					return new ChatLog();
				}
			}
			else
			{
				return new ChatLog();
			}
		}

		public async Task<bool> DeleteChatLog(Guid id)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Member/DeleteChatLog/" + id;
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			return responseMessage.IsSuccessStatusCode;
		}

		#endregion


		#region OpenAI
		public async Task<string> GetAnswer(string prompt)
		{
			var client = new HttpClient();
			string url = "https://ytrackitapi.azurewebsites.net/api/Member/GetAnswer/" + prompt;
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode == true)
			{
				var answer = await responseMessage.Content.ReadAsStringAsync();

				if (answer != null)
				{
					return answer;
				}
				else
				{
					return string.Empty;
				}
			}
			else
			{
				return string.Empty;
			}
		}
		#endregion
	}
}
