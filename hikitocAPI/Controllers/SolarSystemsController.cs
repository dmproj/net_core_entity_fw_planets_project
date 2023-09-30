using hikitocAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace hikitocAPI.Controllers
{
    [Route("api/[controller]")] // localhost:port/api/solarsystems
    [ApiController]
    public class SolarSystemsController : ControllerBase
    {
        private readonly HikitocDbContext hikitocDbContext;

        public SolarSystemsController(HikitocDbContext hikitocDbContext)
        {
            this.hikitocDbContext = hikitocDbContext;
        }
        //GET ALL SOLAR SYSTEMS
        [HttpGet]
        public IActionResult GetAll()
        {
            var solarSystems = hikitocDbContext.SolarSystems.ToList();
            return Ok(new { Message = "Success from controller", Data = solarSystems });
        }

        //GET 1 SOLAR SYSTEM BY ID
        //[HttpGet("{id}")]

        [HttpGet]
        [Route("{id:Guid}")] // localhost:port/api/solarsystems/{id}
        public IActionResult GetById([FromRoute] Guid id) 
        {
            var solarSystems = hikitocDbContext.SolarSystems.SingleOrDefault(item => item.Id == id);

            if (solarSystems == null)
            {
                return NotFound(new { Message = "No Solar System found!" });
            }
            
            return Ok(new { Message = "1 Solar System found!", Data = solarSystems });
        }
    }
}
