namespace ParcelTrackingSystem.Models
{
    public class OrderItem : BaseEntity
    {
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public int OrderId { get; set; }
    }
}