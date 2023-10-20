using hikitocAPI.Models.Domain;

namespace hikitocAPI.StorageRepositories
{
    public interface ISolarSystemStorageRepository
    {
        public Task<List<SolarSystem>> GetAllAsync();
    }
}
