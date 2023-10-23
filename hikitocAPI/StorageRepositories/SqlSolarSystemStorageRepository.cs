using hikitocAPI.Data;
using hikitocAPI.Models.Domain;
using hikitocAPI.Models.DTO;
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

        public async Task<SolarSystem> DeleteByIdAsync(Guid id)
        {
            var solarSystemSingle = await hikitocDbContext.SolarSystems.SingleOrDefaultAsync(item => item.Id == id);

            if (solarSystemSingle == null)
            {
                return null;
            }

            hikitocDbContext.SolarSystems.Remove(solarSystemSingle);
            await hikitocDbContext.SaveChangesAsync();

            return solarSystemSingle;
        }

        public async Task<List<SolarSystem>> GetAllAsync()
        {
            var solarSystems = await hikitocDbContext.SolarSystems.ToListAsync();

            return solarSystems;
        }

        public async Task<SolarSystem> GetByIdAsync(Guid id)
        {
            var solarSystemSingle = await hikitocDbContext.SolarSystems.SingleOrDefaultAsync(item => item.Id == id);

            return solarSystemSingle;
        }

        public async Task<SolarSystem> InsertSingleAsync(SolarSystem solarSystem)
        {
            await hikitocDbContext.SolarSystems.AddAsync(solarSystem);
            await hikitocDbContext.SaveChangesAsync();

            return solarSystem;
        }

        public async Task<SolarSystem> UpdateByIdAsync(Guid id, SolarSystem solarSystem)
        {
            var solarSystemSingle = await hikitocDbContext.SolarSystems.SingleOrDefaultAsync(item => item.Id == id);

            if (solarSystemSingle == null)
            {
                return null;
            }

            solarSystemSingle.Code = solarSystem.Code;
            solarSystemSingle.Name = solarSystem.Name;
            solarSystemSingle.Image = solarSystem.Image;

            await hikitocDbContext.SaveChangesAsync();

            return solarSystemSingle;
        }
    }
}
