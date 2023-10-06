﻿using hikitocAPI.Data;
using hikitocAPI.Models.Domain;
using hikitocAPI.Models.DTO;
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

            var solarSystemsDto = solarSystems.Select(solarSystem => new SolarSystemDto()
            {
                Id = solarSystem.Id,
                Code = solarSystem.Code,
                Name = solarSystem.Name,
                Image = solarSystem.Image,
            }).ToList();

            return Ok(new { Message = "Success from GetAll action method", Data = solarSystemsDto });
        }

        //GET 1 SOLAR SYSTEM BY ID
        //[HttpGet("{id}")]

        [HttpGet]
        [Route("{id:Guid}")] // localhost:port/api/solarsystems/{id}
        public IActionResult GetById([FromRoute] Guid id)
        {
            var solarSystemSingle = hikitocDbContext.SolarSystems.SingleOrDefault(item => item.Id == id);

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

        //POST/INSERT A SOLAR SYSTEM

        [HttpPost] // localhost:port/api/solarsystems/
        public IActionResult InsertSingle([FromBody] InsertSolarSystemDto insertSolarSystemDto)
        {
            var solarSystem = new SolarSystem
            {
                Code = insertSolarSystemDto.Code,
                Name = insertSolarSystemDto.Name,
                Image = insertSolarSystemDto.Image,
            };
            
            hikitocDbContext.SolarSystems.Add(solarSystem);
            hikitocDbContext.SaveChanges();

            var solarSystemDto = new SolarSystemDto
            {
                Id = solarSystem.Id,
                Code = solarSystem.Code,
                Name = solarSystem.Name,
                Image = solarSystem.Image,
            };

            return Created("/api/solarsystems/" + solarSystem.Id, new { Message = "Solar System created!", Data = solarSystemDto });
        }
    }
}

