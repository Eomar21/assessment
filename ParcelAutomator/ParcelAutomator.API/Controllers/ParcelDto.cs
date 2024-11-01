namespace ParcelAutomator.API.Controllers
{
    public class ParcelDto
    {
        public double Weight { get; set; }
        public required string City { get; set; }
        public bool NeedsSigning { get; set; }
        public required string Department { get; set; }
        public double Value { get; set; }
    }
}