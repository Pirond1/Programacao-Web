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

        public void delete(int id)
        {
            this.repository.delete(id);
        }

        public IEnumerable<AreaDTO> getAll()
        {
            var listaArea = this.repository.getAll();
            var listaAreaDTO = mapper.Map<IEnumerable<AreaDTO>>(listaArea);
            return listaAreaDTO;
        }

        public AreaDTO GetArea(int id)
        {
            var area = this.repository.GetArea(id);
            return mapper.Map<AreaDTO>(area);
        }

        public AreaDTO recuperar(Func<Area, bool> expressao)
        {
            var area = this.repository.recuperar(expressao);
            return mapper.Map<AreaDTO>(area);
        }


        public AreaDTO save(AreaDTO dTO)
        {
            Area entidade = mapper.Map<Area>(dTO);

            if (entidade.id == 0)
                repository.addArea(entidade);
            else
                repository.updateArea(entidade);
            dTO = mapper.Map<AreaDTO>(entidade);
            return dTO;
        }
    }
}
