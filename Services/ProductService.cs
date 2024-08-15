using QuickBitesBackend.Interfaces;
using QuickBitesBackend.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickBitesBackend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Business Logic: Get all products
        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        // Business Logic: Get products by store
        public async Task<List<Product>> GetProductsByStore(long storeId)
        {
            return await _productRepository.GetProductsByStore(storeId);
        }

        // Business Logic: Get product by ID
        public async Task<Product?> GetProductById(long id)
        {
            return await _productRepository.GetProductById(id);
        }

        // Business Logic: Create a new product
        public async Task<Product> CreateProduct(Product product)
        {
            // 1. Trim white spaces from the name and description
            product.Name = product.Name.Trim();
            product.Description = product.Description?.Trim();

            // 2. Validate product name
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new Exception("Product name cannot be empty.");
            }

            // 3. Validate price range
            if (product.Price < 0.01m || product.Price > 10000m)
            {
                throw new Exception("Product price must be between $0.01 and $10,000.");
            }

            // 4. Validate stock
            if (product.Quantity < 0)
            {
                throw new Exception("Stock cannot be negative.");
            }

            // 5. Check for duplicates
            var existingProducts = await _productRepository.GetProductsByStore(product.StoreId);
            if (existingProducts != null && existingProducts.Exists(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception($"A product with the name '{product.Name}' already exists in this store.");
            }

            // Business logic passed, now create the product
            return await _productRepository.CreateProduct(product);
        }

        // Business Logic: Update an existing product
        public async Task<Product> UpdateProduct(Product product)
        {
            return await _productRepository.UpdateProduct(product);
        }

        // Business Logic: Delete a product by ID
        public async Task DeleteProduct(long productId)
        {
            var product = await _productRepository.GetProductById(productId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            await _productRepository.DeleteProduct(product);
        }
    }
}
