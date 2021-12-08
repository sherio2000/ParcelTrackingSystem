using System.ComponentModel.DataAnnotations;

namespace ParcelTrackingSystem.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
