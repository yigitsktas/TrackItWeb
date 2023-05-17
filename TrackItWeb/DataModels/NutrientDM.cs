namespace TrackItWeb.DataModels
{
    public class NutrientDM
    {
    }

    public class AddNutrientLogDM
    {
        public int MemberID { get; set; }
        public int NutrientID { get; set; }
        public string? Notes { get; set; }
        public double Portions { get; set; }
        public int ServingType { get; set; }
    }
}
