using AutoMapper;
using Entidades;
using Interfaces.Models;
using Interfaces.Repository;
using ProjetoFinal.DTOs;

namespace Projeto_Final.Models
{
    public class ConsultaModels : IConsultaModels
    {
        private IConsultaRepository repository;
        private IMapper mapper;

        public ConsultaModels(IConsultaRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void delete(int id)
        {
            this.repository.delete(id);
        }

        public IEnumerable<ConsultaDTO> getAll()
        {
            return mapper.Map<IEnumerable<ConsultaDTO>>(repository.getAll());
        }

        public ConsultaDTO GetConsulta(int id)
        {
            var consulta = this.repository.GetConsulta(id);
            return mapper.Map<ConsultaDTO>(consulta);
        }

        public ConsultaDTO recuperar(Func<Consulta, bool> expressao)
        {
            var consulta = this.repository.recuperar(expressao);
            return mapper.Map<ConsultaDTO>(consulta);
        }

        public ConsultaDTO save(ConsultaDTO dTO)
        {
            Consulta entidade = mapper.Map<Consulta>(dTO);

            if (entidade.id == 0)
                repository.addConsulta(entidade);
            else
                repository.updateConsulta(entidade);
            dTO = mapper.Map<ConsultaDTO>(entidade);
            return dTO;
        }
    }
}
