using hikitocAPI.Data;
using hikitocAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace hikitocAPI.StorageRepositories
{
    public class SqlSolarSystemStorageRepository : ISolarSystemStorageRepository
    {
        private readonly HikitocDbContext hikitocDbContext;

        public SqlSolarSystemStorageRepository(HikitocDbContext hikitocDbContext)
        {
            this.hikitocDbContext = hikitocDbContext;
        }
        public async Task<List<SolarSystem>> GetAllAsync()
        {
            var solarSystems = await hikitocDbContext.SolarSystems.ToListAsync();

            return solarSystems;
        }
    }
}
