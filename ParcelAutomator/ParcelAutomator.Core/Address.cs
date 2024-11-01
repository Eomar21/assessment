namespace ParcelAutomator.Core
{
    public class Address
    {
        public required string Street { get; set; }
        public int HouseNumber { get; set; }
        public required string PostalCode { get; set; }
        public required string City { get; set; }
    }
}