using hikitocAPI.Data;
using hikitocAPI.Models.Domain;
using hikitocAPI.Models.DTO;
using hikitocAPI.StorageRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hikitocAPI.Controllers
{
    [Route("api/[controller]")] // localhost:port/api/solarsystems
    [ApiController]
    public class SolarSystemsController : ControllerBase
    {
        private readonly HikitocDbContext hikitocDbContext;
        private readonly ISolarSystemStorageRepository sqlSolarSystemStorageRepository;

        public SolarSystemsController(HikitocDbContext hikitocDbContext, ISolarSystemStorageRepository sqlSolarSystemStorageRepository)
        {
            this.hikitocDbContext = hikitocDbContext;
            this.sqlSolarSystemStorageRepository = sqlSolarSystemStorageRepository;
        }

        //GET ALL SOLAR SYSTEMS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var solarSystems = await sqlSolarSystemStorageRepository.GetAllAsync();

                var solarSystemsDto = solarSystems.Select(solarSystem => new SolarSystemDto()
                {
                    Id = solarSystem.Id,
                    Code = solarSystem.Code,
                    Name = solarSystem.Name,
                    Image = solarSystem.Image,
                }).ToList();

                return Ok(new { Message = "Success from GetAll action method", Data = solarSystemsDto });
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { Message = "Database error occurred", Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred", Error = ex.Message });
            }
        }


        //GET 1 SOLAR SYSTEM BY ID
        //[HttpGet("{id}")]
        [HttpGet]
        [Route("{id:Guid}")] // localhost:port/api/solarsystems/{id}
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                var solarSystemSingle = await hikitocDbContext.SolarSystems.SingleOrDefaultAsync(item => item.Id == id);

                if (solarSystemSingle == null)
                {
                    return NotFound(new { Message = "No Solar System found!" });
                }

                var solarSystemDto = new SolarSystemDto
                {
                    Id = solarSystemSingle.Id,
                    Code = solarSystemSingle.Code,
                    Name = solarSystemSingle.Name,
                    Image = solarSystemSingle.Image,
                };

                return Ok(new { Message = "1 Solar System found!", Data = solarSystemDto });
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { Message = "Database update error occurred", Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred", Error = ex.Message });
            }
        }


        //POST/INSERT A SOLAR SYSTEM
        [HttpPost] // localhost:port/api/solarsystems/
        public async Task<IActionResult> InsertSingle([FromBody] InsertSolarSystemDto insertSolarSystemDto)
        {
            try
            {
                var solarSystem = new SolarSystem
                {
                    Code = insertSolarSystemDto.Code,
                    Name = insertSolarSystemDto.Name,
                    Image = insertSolarSystemDto.Image,
                };

                hikitocDbContext.SolarSystems.Add(solarSystem);
                await hikitocDbContext.SaveChangesAsync();

                var solarSystemDto = new SolarSystemDto
                {
                    Id = solarSystem.Id,
                    Code = solarSystem.Code,
                    Name = solarSystem.Name,
                    Image = solarSystem.Image,
                };

                return Created("/api/solarsystems/" + solarSystem.Id, new { Message = "Solar System created!", Data = solarSystemDto });
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { Message = "Database update error occurred", Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred", Error = ex.Message });
            }
        }


        //PUT/UPDATE 1 SOLAR SYSTEM BY ID
        //[HttpPut("{id}")]
        [HttpPut]
        [Route("{id:Guid}")] // localhost:port/api/solarsystems/{id}
        public async Task<IActionResult> UpdateById([FromRoute] Guid id, [FromBody] UpdateSolarSystemDto updateSolarSystemDto)
        {
            try
            {
                var solarSystemSingle = await hikitocDbContext.SolarSystems.SingleOrDefaultAsync(item => item.Id == id);

                if (solarSystemSingle == null)
                {
                    return NotFound(new { Message = "No Solar System found!" });
                }

                solarSystemSingle.Code = updateSolarSystemDto.Code;
                solarSystemSingle.Name = updateSolarSystemDto.Name;
                solarSystemSingle.Image = updateSolarSystemDto.Image;

                await hikitocDbContext.SaveChangesAsync();

                var solarSystemDto = new SolarSystemDto
                {
                    Id = solarSystemSingle.Id,
                    Code = solarSystemSingle.Code,
                    Name = solarSystemSingle.Name,
                    Image = solarSystemSingle.Image,
                };

                return Ok(new { Message = "1 Solar System updated!", Data = solarSystemDto });
            }

            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Database Update Error: {ex}");

                return StatusCode(500, new { Message = "An error occured while updating the database" });
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");

                return StatusCode(500, new { Message = "An error occured while processing the request" });
            }
        }

        //DELETE A SOLAR SYSTEM BY ID
        //[HttpDelete("{id}")]

        [HttpDelete]
        [Route("{id:Guid}")] // localhost:port/api/solarsystems/{id}
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            try
            {
                var solarSystemSingle = await hikitocDbContext.SolarSystems.SingleOrDefaultAsync(item => item.Id == id);

                if (solarSystemSingle == null)
                {
                    return NotFound(new { Message = "No Solar System found!" });
                }

                hikitocDbContext.SolarSystems.Remove(solarSystemSingle);
                await hikitocDbContext.SaveChangesAsync();

                return Ok(new { Message = "1 Solar System deleted!" });
            }

            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Database Update Error: {ex}");

                return StatusCode(500, new { Message = "An error occured while updating the database" });
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");

                return StatusCode(500, new { Message = "An error occured while processing the request" });
            }
        }

    }
}
