using AutoMapper;
using hikitocAPI.Models.Domain;
using hikitocAPI.Models.DTO;

namespace hikitocAPI.MappingProfiles
{
    public class SolarSystemsProfile : Profile
    {
        public SolarSystemsProfile()
        {
            CreateMap<SolarSystem, SolarSystemDto>();
            CreateMap<SolarSystemDto, SolarSystem>();
        }
    }
}
