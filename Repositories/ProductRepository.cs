using QuickBitesBackend.Data;
using QuickBitesBackend.Interfaces;
using QuickBitesBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace QuickBitesBackend.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<List<Product>> GetProductsByStore(long storeId)
        {
            return await _dbContext.Products.Where(p => p.StoreId == storeId).ToListAsync();
        }

        public async Task<Product?> GetProductById(long id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(Product product)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
