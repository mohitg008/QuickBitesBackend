using QuickBitesBackend.Models;

namespace QuickBitesBackend.Interfaces
{
    public interface IStoreRepository
    {
        Task<List<Store>> GetAllStores();
        Task<List<Store>> GetStoresByCity(string city);
        Task<Store?> GetStoreById(long id);
        Task<Store> CreateStore(Store store);
        Task<Store> UpdateStore(Store store);
        Task DeleteStore(Store store);

        Task<List<Store>> GetStoresByCategory(string category);

    }
}
