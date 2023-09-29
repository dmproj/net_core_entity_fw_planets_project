using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hikitocAPI.Controllers
{
    [Route("api/[controller]")] //localhost:port/api/planets
    [ApiController]
    public class PlanetsController : ControllerBase

    {
        [HttpGet]
        public IActionResult GetAllPlanets()
        {
            string[] planets = new string[] { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Pluto" };
            return new JsonResult(planets);
        }
    }
}
