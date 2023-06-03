using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
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
			string url = "https://localhost:7004/api/Nutrient/GetRecipes";

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
			string url = "https://localhost:7004/api/Nutrient/GetMemberRecipes/" + id;

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

		public async Task<bool> CreateRecipe(string info)
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Nutrient/CreateRecipe/" + info;
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteRecipe(int id)
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Nutrient/DeleteRecipe/" + id;
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<List<Nutrient>> GetNutrients()
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Nutrient/GetNutrients";
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

		public async Task<bool> CreateMemberNutrient(string info)
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Nutrient/CreateMemberNutrient/" + info + "/a";
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteMemberNutrient(int id)
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Nutrient/DeleteMemberNutrient/" + id;
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<MemberNutrient> GetMemberNutrientLog(int id)
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Nutrient/GetMemberNutrientLog/" + id;
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
			string url = "https://localhost:7004/api/Nutrient/GetMemberNutrientLogs/" + id;
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

		public async Task<List<MemberNutrient>> GetMemberNutrientFilteredLogs(int id, string name, string orderBy)
		{
			if (name == null)
			{
				name = Guid.NewGuid().ToString();
			}

			var client = new HttpClient();
			string url = "https://localhost:7004/api/Nutrient/GetMemberNutrientFilteredLogs/"+ name + "/" + orderBy + "/" + id;
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
			string url = "https://localhost:7004/api/Nutrient/GetNutrientByID/" + id;
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

		public async Task<Recipe> GetRecipe(int id)
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Nutrient/GetRecipe/" + id;
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

		public async Task<List<Recipe>> GetRandomRecipes()
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Nutrient/GetRandomRecipe";

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

		public async Task<List<NAnalytics>> GetAnalytics(int id, string date, string info)
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Nutrient/GetNutrientAnalytics/" + id + "/" + info + "/" + date;

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
			string url = "https://localhost:7004/api/Workout/GetMSWorkouts/" + id;

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
			string url = "https://localhost:7004/api/Workout/CreateMSWorkout/" + info;
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteMSWorkout(int id)
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Workout/DeleteMSWorkout/" + id;
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<MemberSpecificWorkout> GetMSWorkout(int id)
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Workout/GetMSWorkout/" + id;

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

		public async Task<Workout> GetWorkout(int id)
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Workout/GetWorkout/" + id;

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
			string url = "https://localhost:7004/api/Workout/GetWorkouts/";

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
			string url = "https://localhost:7004/api/Workout/GetWorkoutType/" + id;

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
			string url = "https://localhost:7004/api/Workout/GetMuscleGroup/" + id;

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
			string url = "https://localhost:7004/api/Workout/GetWorkoutTypes/";

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
			string url = "https://localhost:7004/api/Workout/GetMuscleGroups/";

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
			string url = "https://localhost:7004/api/Workout/GetRandomWorkout";

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

		#endregion


		#region Authentication

		public async Task<Member> CreateUser(string info)
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Member/CreateUser/" + info;
			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

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
			string url = "https://localhost:7004/api/Member/Login/" + username + "/" + password;

			client.BaseAddress = new Uri(url);
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			return responseMessage.IsSuccessStatusCode;
		}

		#endregion


		#region Member

		public async Task<Member> GetMember(int id)
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Member/GetMember/" + id;
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
			string url = "https://localhost:7004/api/Member/GetMemberMetric/" + id;
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

		public async Task<bool> CreateMemberMetric(string info)
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Member/CreateMemberMetric/" + info;
			HttpResponseMessage responseMessage = await client.GetAsync(url);

			return responseMessage.IsSuccessStatusCode;
		}
		#endregion


		#region OpenAI
		public async Task<string> GetAnswer(string prompt)
		{
			var client = new HttpClient();
			string url = "https://localhost:7004/api/Member/GetAnswer/" + prompt;
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
