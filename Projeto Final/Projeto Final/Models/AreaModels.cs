using AutoMapper;
using Interfaces.Models;
using ProjetoFinal.DTOs;
using Entidades;
using Interfaces.Repository;

namespace Projeto_Final.Models
{
    public class AreaModels : IAreaModels
    {
        private IAreaRepository repository;
        private IMapper mapper;

        public AreaModels(IAreaRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<AreaDTO> getAll()
        {
            return mapper.Map<IEnumerable<AreaDTO>>(repository.getAll());
        }

        public AreaDTO save(AreaDTO dTO)
        {
            Area entidade = mapper.Map<Area>(dTO);
            repository.addArea(entidade);
            dTO = mapper.Map<AreaDTO>(entidade);
            return dTO;
        }
    }
}
