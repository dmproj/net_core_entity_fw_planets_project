using hikitocAPI.Models.Domain;
using hikitocAPI.Models.Queries;

namespace hikitocAPI.StorageRepositories
{
    public interface IPlanetStorageRepository
    {
        public Task<List<Planet>> GetAllAsync(PlanetsQueryParameters? planetsQueryParameters);
        public Task<Planet> GetByIdAsync(Guid id);
        public Task<Planet> InsertSingleAsync(Planet planet);
        public Task<Planet?> UpdateByIdAsync(Guid id, Planet planet);
        public Task<Planet> DeleteByIdAsync(Guid id);
    }
}