using QuickBitesBackend.Models;

namespace QuickBitesBackend.Interfaces
{
    public interface IStoreService
    {
        Task<List<Store>> GetAllStores();
        Task<List<Store>> GetStoresByCategory(string category);
        Task<List<Store>> GetStoresByCity(string city);
        Task<Store?> GetStoreById(long id);
        Task<Store> CreateStore(Store store);
        Task<Store> UpdateStore(Store store);
        Task DeleteStore(long id);
    }
}
