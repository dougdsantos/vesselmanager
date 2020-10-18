namespace VesselManager.Domain.DTO
{
    public abstract class BaseRequestReturn
    {
        public string status { get; set; }
        public string message { get; set; }
    }
}
