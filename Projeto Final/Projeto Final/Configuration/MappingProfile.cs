using AutoMapper;
using Entidades;
using ProjetoFinal.DTOs;

namespace ProjetoFinal.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Area, AreaDTO>().ReverseMap();
        }
    }
}
