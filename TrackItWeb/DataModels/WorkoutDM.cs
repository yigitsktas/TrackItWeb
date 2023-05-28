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

	public class MSWorkoutAddJsonDM
	{
		public string? MemberID { get; set; }
		public int MuscleGroup { get; set; }
		public string? WorkoutType { get; set; }
		public string? WorkoutName { get; set; }
		public string? Description { get; set; }
		public string? Link { get; set; }
	}

	public class WAnalytics
	{
		public string? X { get; set; }
		public string? Y { get; set; }
	}
}
