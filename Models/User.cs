using System.ComponentModel.DataAnnotations;

namespace QuickBitesBackend.Models
{
    public abstract class User
    {
        [Key]
        public long Id { get; set; }

        [Required, MaxLength(20)]
        public string Username { get; set; }

        [Required, MaxLength(60)]
        public string Password { get; set; }

        [Required, MaxLength(254)]
        public string Email { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        public string? Image { get; set; }
        public string? ImagePublicId { get; set; }

        [Required, MaxLength(20)]
        public string Role { get; set; }
    }
}
