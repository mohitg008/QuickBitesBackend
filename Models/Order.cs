using System.ComponentModel.DataAnnotations;

namespace QuickBitesBackend.Models
{
    public class Order
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public bool IsCanceled { get; set; } = false;

        [Required]
        public DateTime CreatedAt { get; set; }

        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        public long StoreId { get; set; }
        public Store Store { get; set; }

        [Required]
        public decimal ItemsPrice { get; set; }

        [Required]
        public decimal DeliveryFee { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required, MaxLength(200)]
        public string Address { get; set; }

        [Required]
        public string PaymentIntentId { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

        public OrderStatus OrderStatus
        {
            get
            {
                return IsCanceled ? OrderStatus.Canceled :
                       DateTime.UtcNow >= CreatedAt.AddMinutes(Store.DeliveryTimeInMinutes) ? OrderStatus.Completed :
                       OrderStatus.Pending;
            }
        }
    }
}
