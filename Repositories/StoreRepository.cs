using QuickBitesBackend.Data;
using QuickBitesBackend.Interfaces;
using QuickBitesBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace QuickBitesBackend.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext _dbContext;

        public StoreRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Store>> GetAllStores()
        {
            return await _dbContext.Stores.ToListAsync();
        }

        public async Task<List<Store>> GetStoresByCategory(string category)
        {
            return await _dbContext.Stores.Where(s => s.Category.ToLower() == category.ToLower()).ToListAsync();
        }

        public async Task<List<Store>> GetStoresByCity(string city)
        {
            return await _dbContext.Stores.Where(s => s.City.ToLower() == city.ToLower()).ToListAsync();
        }

        public async Task<Store?> GetStoreById(long id)
        {
            return await _dbContext.Stores.FindAsync(id);
        }

        public async Task<Store> CreateStore(Store store)
        {
            await _dbContext.Stores.AddAsync(store);
            await _dbContext.SaveChangesAsync();
            return store;
        }

        public async Task<Store> UpdateStore(Store store)
        {
            _dbContext.Stores.Update(store);
            await _dbContext.SaveChangesAsync();
            return store;
        }

        public async Task DeleteStore(Store store)
        {
            _dbContext.Stores.Remove(store);
            await _dbContext.SaveChangesAsync();
        }
    }
}
