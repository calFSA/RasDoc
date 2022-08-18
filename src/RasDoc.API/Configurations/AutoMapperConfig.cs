using AutoMapper;
using Rasdoc.DTO.Models;
using Rasdoc.Entities.Models;

namespace RasDoc.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Colaborador, ColaboradorDTO>().ReverseMap();
        }
    }
}
