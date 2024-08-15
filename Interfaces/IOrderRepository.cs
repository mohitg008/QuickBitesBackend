using QuickBitesBackend.Models;

namespace QuickBitesBackend.Interfaces
{
    public interface IOrderRepository
    {
        
            Task<List<Order>> GetAllOrders();
            Task<Order?> GetOrderById(long id);
            Task<List<Order>> GetOrdersByCustomer(long customerId);
            Task<Order> CreateOrder(Order order);
            Task<Order> UpdateOrder(Order order);
        
    }
}
