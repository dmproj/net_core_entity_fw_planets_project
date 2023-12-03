using hikitocAPI.Models.Domain;

namespace hikitocAPI.StorageRepositories
{
    public interface IPlanetStorageRepository
    {
        public Task<List<Planet>> GetAllAsync();
        public Task<Planet> GetByIdAsync(Guid id);
        public Task<Planet> InsertSingleAsync(Planet planet);
        public Task<Planet?> UpdateByIdAsync(Guid id, Planet planet);
        public Task<Planet> DeleteByIdAsync(Guid id);
    }
}