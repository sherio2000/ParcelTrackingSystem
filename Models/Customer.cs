namespace ParcelTrackingSystem.Models
{
    public class Customer : BaseEntity
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNum1 { get; set; }
        public string? CustomerPhoneNum2 { get; set; }
        public Address CustomerAddress { get; set; }
    }
}
