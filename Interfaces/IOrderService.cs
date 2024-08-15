using QuickBitesBackend.Models;
using QuickBitesBackend.Interfaces;
namespace QuickBitesBackend.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrders();
        Task<Order?> GetOrderById(long id);
        Task<List<Order>> GetOrdersByCustomer(long customerId);
        Task<Order> CreateOrder(Order order);
        Task<Order> UpdateOrder(Order order);
    }
}
