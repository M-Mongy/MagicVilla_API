using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI
{
    public class MappingConfig:Profile 
    {
        public MappingConfig()
        {
            CreateMap<Villa, VillaDto>().ReverseMap();
            CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            CreateMap<Villa, VillaUpdateDTO>().ReverseMap();

            // ==================== THIS IS THE FIX ====================
            // This section explicitly tells AutoMapper how to map the 
            // VillaNumber models and DTOs, ensuring the properties match.

            // Mapping from VillaNumber (database model) to VillaNumberDTO (API response)
            CreateMap<VillaNumber, VillaNumberDto>();

            // Mapping from DTOs (API request) to the VillaNumber model
            CreateMap<VillaNumberDtoCreate, VillaNumber>();
            CreateMap<VillaNumberDtoUpdate, VillaNumber>();
        }
    }
}
