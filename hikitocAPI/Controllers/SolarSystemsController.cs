using hikitocAPI.Data;
using hikitocAPI.Models.Domain;
using Microsoft.AspNetCore.Http;
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
    }
}
