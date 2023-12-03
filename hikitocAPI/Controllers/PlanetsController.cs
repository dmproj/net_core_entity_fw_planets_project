using AutoMapper;
using hikitocAPI.Models.Domain;
using hikitocAPI.Models.DTO;
using hikitocAPI.StorageRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace hikitocAPI.Controllers
{
    [Route("api/[controller]")] //localhost:port/api/planets
    [ApiController]
    public class PlanetsController : ControllerBase

    {
        private readonly IPlanetStorageRepository sqlPlanetStorageRepository;
        private readonly IMapper mapper;

        public PlanetsController(IPlanetStorageRepository sqlPlanetStorageRepository, IMapper mapper)
        {
            this.sqlPlanetStorageRepository = sqlPlanetStorageRepository;
            this.mapper = mapper;
        }

        //GET ALL PLANETS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var planets = await sqlPlanetStorageRepository.GetAllAsync();

                var planetsDto = mapper.Map<List<PlanetDto>>(planets);

                return Ok(new { Message = "Success from GetAll action method", Data = planetsDto });
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


        //GET 1 PLANET BY ID
        //[HttpGet("{id}")]
        [HttpGet]
        [Route("{id:Guid}")] // localhost:port/api/planets/{id}
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                var planetSingle = await sqlPlanetStorageRepository.GetByIdAsync(id);

                if (planetSingle == null)
                {
                    return NotFound(new { Message = "No planet found!" });
                }

                var planetDto = mapper.Map<PlanetDto>(planetSingle);

                return Ok(new { Message = "1 planet found!", Data = planetDto });
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


        //POST/INSERT A PLANET
        [HttpPost] // localhost:port/api/planets/
        public async Task<IActionResult> InsertSingle([FromBody] InsertPlanetDto insertPlanetDto)
        {
            try
            {
                var planet = mapper.Map<Planet>(insertPlanetDto);

                //if (!ModelState.IsValid)
                //{
                //    return BadRequest(new { Message = "error from !ModelState.IsValid", ModelState });
                //}

                var validationContext = new ValidationContext(planet);
                var validationResults = new List<ValidationResult>();

                if (!Validator.TryValidateObject(planet, validationContext, validationResults, true))
                {
                    return BadRequest(new { Message = "Custom validation error", Errors = validationResults.Select(r => r.ErrorMessage) });
                }

                planet = await sqlPlanetStorageRepository.InsertSingleAsync(planet);

                var planetDto = mapper.Map<PlanetDto>(planet);

                return Created("/api/planets/" + planet.PlanetId, new { Message = "planet created!", Data = planetDto });
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


        //PUT/UPDATE 1 PLANET BY ID
        //[HttpPut("{id}")]
        [HttpPut]
        [Route("{id:Guid}")] // localhost:port/api/planets/{id}
        public async Task<IActionResult> UpdateById([FromRoute] Guid id, [FromBody] UpdatePlanetDto updatePlanetDto)
        {
            try
            {
                var planetSingle = mapper.Map<Planet>(updatePlanetDto);

                planetSingle = await sqlPlanetStorageRepository.UpdateByIdAsync(id, planetSingle);

                if (planetSingle == null)
                {
                    return NotFound(new { Message = "No planet found!" });
                }

                var planetDto = mapper.Map<PlanetDto>(planetSingle);

                return Ok(new { Message = "1 planet updated!", Data = planetDto });
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

        //DELETE A PLANET BY ID
        //[HttpDelete("{id}")]

        [HttpDelete]
        [Route("{id:Guid}")] // localhost:port/api/planets/{id}
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            try
            {
                var planetSingle = await sqlPlanetStorageRepository.DeleteByIdAsync(id);

                if (planetSingle == null)
                {
                    return NotFound(new { Message = "No planet found!" });
                }

                return Ok(new { Message = "1 planet deleted!" });
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