namespace ParcelTrackingSystem.Models
{
    public class Order : BaseEntity
    {
        public string OrderName { get; set; }
        public string OriginLocation { get; set; }
        public string DestinationLocation { get; set; }
        public int OrderStatusId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string TrackingCode { get; set; }
        public string? OrderRemarks { get; set; }
    }
}
