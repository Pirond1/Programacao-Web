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
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();
            CreateMap<Pagamento, PagamentoDTO>().ReverseMap();
            CreateMap<Servico, ServicoDTO>().ReverseMap();
        }
    }
}
