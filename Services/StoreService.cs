using QuickBitesBackend.Interfaces;
using QuickBitesBackend.Models;

namespace QuickBitesBackend.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        // Business logic: Get all stores
        public async Task<List<Store>> GetAllStores()
        {
            var stores = await _storeRepository.GetAllStores();

            // Business logic: If no stores found, return an empty list or handle accordingly
            if (stores == null || stores.Count == 0)
            {
                throw new Exception("No stores available at the moment.");
            }

            return stores;
        }

        // Business logic: Get stores by category
        public async Task<List<Store>> GetStoresByCategory(string category)
        {
            // Business logic: Validate category input
            if (string.IsNullOrEmpty(category))
            {
                throw new ArgumentException("Category cannot be empty.");
            }

            var stores = await _storeRepository.GetStoresByCategory(category);

            // Business logic: Handle if no stores are found in this category
            if (stores == null || stores.Count == 0)
            {
                throw new Exception($"No stores found in category '{category}'.");
            }

            return stores;
        }

        // Business logic: Get stores by city
        public async Task<List<Store>> GetStoresByCity(string city)
        {
            // Business logic: Validate city input
            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentException("City cannot be empty.");
            }

            var stores = await _storeRepository.GetStoresByCity(city);

            // Business logic: Handle if no stores are found in this city
            if (stores == null || stores.Count == 0)
            {
                throw new Exception($"No stores found in city '{city}'.");
            }

            return stores;
        }

        // Business logic: Get store by id
        public async Task<Store?> GetStoreById(long id)
        {
            // Business logic: Validate ID
            if (id <= 0)
            {
                throw new ArgumentException("Store ID must be a positive number.");
            }

            var store = await _storeRepository.GetStoreById(id);

            // Business logic: Handle if store is not found
            if (store == null)
            {
                throw new Exception($"Store with ID {id} not found.");
            }

            return store;
        }

        // Business logic: Create new store
        public async Task<Store> CreateStore(Store store)
        {
            // Business logic: Validate store input
            if (store == null)
            {
                throw new ArgumentException("Store data cannot be null.");
            }

            if (string.IsNullOrEmpty(store.Name))
            {
                throw new ArgumentException("Store name is required.");
            }

            if (store.DeliveryFee < 0)
            {
                throw new ArgumentException("Delivery fee cannot be negative.");
            }

            // Add more business rules for other fields if necessary

            // Creating store in the database
            return await _storeRepository.CreateStore(store);
        }

        // Business logic: Update store
        public async Task<Store> UpdateStore(Store store)
        {
            // Business logic: Validate store input
            if (store == null || store.Id <= 0)
            {
                throw new ArgumentException("Store data is invalid.");
            }

            if (string.IsNullOrEmpty(store.Name))
            {
                throw new ArgumentException("Store name is required.");
            }

            if (store.DeliveryFee < 0)
            {
                throw new ArgumentException("Delivery fee cannot be negative.");
            }

            // Check if store exists before updating
            var existingStore = await _storeRepository.GetStoreById(store.Id);
            if (existingStore == null)
            {
                throw new Exception($"Store with ID {store.Id} not found.");
            }

            // Update store in the database
            return await _storeRepository.UpdateStore(store);
        }

        // Business logic: Delete store
        public async Task DeleteStore(long id)
        {
            // Business logic: Validate store ID
            if (id <= 0)
            {
                throw new ArgumentException("Store ID must be a positive number.");
            }

            var store = await _storeRepository.GetStoreById(id);

            // Business logic: Handle if store is not found
            if (store == null)
            {
                throw new Exception($"Store with ID {id} not found.");
            }

            // If the store has active orders, prevent deletion
            if (store.Orders != null && store.Orders.Count > 0)
            {
                throw new InvalidOperationException("Cannot delete store with active orders.");
            }

            // Proceed with deleting the store
            await _storeRepository.DeleteStore(store);
        }
    }
}
