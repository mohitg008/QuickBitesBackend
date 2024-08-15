namespace QuickBitesBackend.Models
{
    public class Customer : User
    {
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
