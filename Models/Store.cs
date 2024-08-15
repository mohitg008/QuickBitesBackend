using System.ComponentModel.DataAnnotations;

namespace QuickBitesBackend.Models
{
    public class Store
    {
        [Key]
        public long Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required, MaxLength(100)]
        public string Address { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        [Required, MaxLength(10)]
        public string PostalCode { get; set; }

        [Required, MaxLength(20)]
        public string Phone { get; set; }

        public long PartnerId { get; set; }
        public Partner Partner { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public int DeliveryTimeInMinutes { get; set; }
        public decimal DeliveryFee { get; set; }

        [Required, MaxLength(20)]
        public string Category { get; set; }

        public string? Image { get; set; }
        public string? ImagePublicId { get; set; }
    }
}
