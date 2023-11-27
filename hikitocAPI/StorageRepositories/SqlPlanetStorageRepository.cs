using hikitocAPI.Data;
using hikitocAPI.Models.Domain;
using hikitocAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace hikitocAPI.StorageRepositories
{
    public class SqlPlanetStorageRepository : IPlanetStorageRepository
    {
        private readonly HikitocDbContext hikitocDbContext;

        public SqlPlanetStorageRepository(HikitocDbContext hikitocDbContext)
        {
            this.hikitocDbContext = hikitocDbContext;
        }

        public async Task<Planet> DeleteByIdAsync(Guid id)
        {
            var planetSingle = await hikitocDbContext.Planets.SingleOrDefaultAsync(item => item.PlanetId == id);

            if (planetSingle == null)
            {
                return null;
            }

            hikitocDbContext.Planets.Remove(planetSingle);
            await hikitocDbContext.SaveChangesAsync();

            return planetSingle;
        }

        public async Task<List<Planet>> GetAllAsync()
        {
            var planets = await hikitocDbContext.Planets.ToListAsync();

            return planets;
        }

        public async Task<Planet> GetByIdAsync(Guid id)
        {
            var planetSingle = await hikitocDbContext.Planets.SingleOrDefaultAsync(item => item.PlanetId == id);

            return planetSingle;
        }

        public async Task<Planet> InsertSingleAsync(Planet planet)
        {
            await hikitocDbContext.Planets.AddAsync(planet);
            await hikitocDbContext.SaveChangesAsync();

            return planet;
        }

        public async Task<Planet> UpdateByIdAsync(Guid id, Planet planet)
        {
            var planetSingle = await hikitocDbContext.Planets.SingleOrDefaultAsync(item => item.PlanetId == id);

            if (planetSingle == null)
            {
                return null;
            }

            planetSingle.Name = planet.Name;
            planetSingle.Description = planet.Description;
            planetSingle.DiameterKm = planet.DiameterKm;
            planetSingle.Image = planet.Image; 
            planetSingle.SolarSystemId = planet.SolarSystemId;
            planetSingle.WaterId = planet.WaterId;

            await hikitocDbContext.SaveChangesAsync();

            return planetSingle;
        }
    }
}
