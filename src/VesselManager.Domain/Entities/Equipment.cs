namespace VesselManager.Domain.Entities
{
    public class Equipment : Base
    {
        public bool status { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public Vessel vessel { get; set; }
    }
}
