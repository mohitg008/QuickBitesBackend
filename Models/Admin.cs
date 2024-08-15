namespace QuickBitesBackend.Models
{
    public class Admin : User
    {
        public bool IsSuperAdmin { get; set; } = false;

    }
}
