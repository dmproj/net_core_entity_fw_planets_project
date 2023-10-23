using hikitocAPI.Models.Domain;

namespace hikitocAPI.StorageRepositories
{
    public interface ISolarSystemStorageRepository
    {
        public Task<List<SolarSystem>> GetAllAsync();
        public Task<SolarSystem> GetByIdAsync(Guid id);
        public Task<SolarSystem> InsertSingleAsync(SolarSystem solarSystem);
        public Task<SolarSystem?> UpdateByIdAsync(Guid id, SolarSystem solarSystem);
        public Task<SolarSystem> DeleteByIdAsync(Guid id);
    }
}
