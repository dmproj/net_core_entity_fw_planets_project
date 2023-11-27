using AutoMapper;
using hikitocAPI.Models.Domain;
using hikitocAPI.Models.DTO;

namespace hikitocAPI.MappingProfiles
{
    public class SolarSystemsProfile : Profile
    {
        public SolarSystemsProfile()
        {
            CreateMap<SolarSystem, SolarSystemDto>().ReverseMap();
            CreateMap<InsertSolarSystemDto, SolarSystem>().ReverseMap();
            CreateMap<UpdateSolarSystemDto, SolarSystem>().ReverseMap();

            CreateMap<Planet, PlanetDto>().ReverseMap();
            CreateMap<InsertPlanetDto, Planet>().ReverseMap();
            CreateMap<UpdatePlanetDto, Planet>().ReverseMap();

            //CreateMap<UpdateSolarSystemDto, SolarSystem>()
            //    .ForMember(dest => dest.Code, opt => opt.MapFrom(src =>src.Name))
            //    .ReverseMap();

            //var updateSolarSystemDto = new UpdateSolarSystemDto
            //{
            //    Code = "STRN",
            //    Name = "Saturn",
            //    Image = "saturn.jpg"
            //};

            //var one = Mapper.Map<SolarSystem>(updateSolarSystemDto);
            //var two = Mapper.Map<UpdateSolarSystemDto>(one);

            //var solarSystemsDto = solarSystems.Select(solarSystem => new SolarSystemDto()
            //{
            //    Id = solarSystem.Id,
            //    Code = solarSystem.Code,
            //    Name = solarSystem.Name,
            //    Image = solarSystem.Image,
            //}).ToList();

        }
    }
}