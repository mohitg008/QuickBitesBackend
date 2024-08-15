using System.ComponentModel.DataAnnotations;
using QuickBitesBackend.Enum;
namespace QuickBitesBackend.Models
{
    public class RefreshToken
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public int ExpiresIn { get; set; }

        [Required]
        public long UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        public UserType UserType { get; set; }

        public User User { get; set; }
    }
}
