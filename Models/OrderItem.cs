using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuickBitesBackend.Models
{
    public class OrderItem
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required, MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        public string? ProductImage { get; set; }
        public string ProductDescription { get; set; }
    }
}
