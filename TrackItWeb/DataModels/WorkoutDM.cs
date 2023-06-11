namespace TrackItWeb.DataModels
{
	public class WorkoutDM
	{

	}

	public class MSWorkoutAddDM
	{
		public int MemberID { get; set; }
		public int MuscleGroupID { get; set; }
		public int WorkoutTypeID { get; set; }
        public string? WorkoutName { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
    }

	public class MSUpdateAddDM
	{
		public int MemberSpecificWorkoutID { get; set; }
		public int GUID { get; set; }
		public int MemberID { get; set; }
		public int MuscleGroupID { get; set; }
		public int WorkoutTypeID { get; set; }
		public string? WorkoutName { get; set; }
		public string? Description { get; set; }
		public string? Link { get; set; }
	}

	public class MSWorkoutAddJsonDM
	{
		public string? MemberID { get; set; }
		public int MuscleGroup { get; set; }
		public string? WorkoutType { get; set; }
		public string? WorkoutName { get; set; }
		public string? Description { get; set; }
		public string? Link { get; set; }
	}

	public class WorkoutAnalytics
	{
		public string? Name { get; set; }
		public List<WorkoutLogStat>? Logs { get; set; }
	}

	public class WorkoutLogStat
	{
		public string? Name { get; set; }
		public string? Reps { get; set; }
		public string? Weight { get; set; }
	}
}
