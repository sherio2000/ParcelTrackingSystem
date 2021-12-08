namespace ParcelTrackingSystem.Models
{
    public class Address : BaseEntity
    {
        public int CustomerId { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? ZIPCode { get; set; }
        public string? StreetName { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
    }
}