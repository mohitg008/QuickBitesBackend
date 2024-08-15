using System.ComponentModel.DataAnnotations;

namespace QuickBitesBackend.Models
{
    public class Partner : User
    {
        [Required]
        public PartnerStatus Status { get; set; }

        public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
    }
}
