using System.ComponentModel.DataAnnotations;

namespace QuickBitesBackend.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public long StoreId { get; set; }
        public Store Store { get; set; }

        public string? Image { get; set; }
        public string? ImagePublicId { get; set; }

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    } 
}
