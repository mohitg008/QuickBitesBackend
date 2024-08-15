using QuickBitesBackend.Models;

namespace QuickBitesBackend.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProductsByStore(long storeId);
        Task<Product?> GetProductById(long id);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(long productId);
    }
}
