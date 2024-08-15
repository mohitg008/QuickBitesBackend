using QuickBitesBackend.Interfaces;
using QuickBitesBackend.Models;
using QuickBitesBackend.Repositories;
namespace QuickBitesBackend.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _orderRepository.GetAllOrders();
        }

        public async Task<Order?> GetOrderById(long id)
        {
            return await _orderRepository.GetOrderById(id);
        }

        public async Task<List<Order>> GetOrdersByCustomer(long customerId)
        {
            return await _orderRepository.GetOrdersByCustomer(customerId);
        }

        public async Task<Order> CreateOrder(Order order)
        {
            // Here we can calculate the total price, validate the products, etc.
            order.TotalPrice = order.ItemsPrice + order.DeliveryFee;
            return await _orderRepository.CreateOrder(order);
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            return await _orderRepository.UpdateOrder(order);
        }
    }
}
