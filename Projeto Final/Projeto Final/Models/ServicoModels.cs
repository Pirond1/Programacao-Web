using AutoMapper;
using Entidades;
using Interfaces.Models;
using Interfaces.Repository;
using ProjetoFinal.DTOs;

namespace Projeto_Final.Models
{
    public class ServicoModels : IServicoModels
    {
        private IServicoRepository repository;
        private IMapper mapper;

        public ServicoModels(IServicoRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void delete(int id)
        {
            this.repository.delete(id);
        }

        public IEnumerable<ServicoDTO> getAll()
        {
            return mapper.Map<IEnumerable<ServicoDTO>>(repository.getAll());
        }

        public ServicoDTO GetServico(int id)
        {
            var servico = this.repository.GetServico(id);
            return mapper.Map<ServicoDTO>(servico);
        }

        public ServicoDTO recuperar(Func<Servico, bool> expressao)
        {
            var servico = this.repository.recuperar(expressao);
            return mapper.Map<ServicoDTO>(servico);
        }

        public ServicoDTO save(ServicoDTO dTO)
        {
            Servico entidade = mapper.Map<Servico>(dTO);

            if (entidade.id == 0)
                repository.addServico(entidade);
            else
                repository.updateServico(entidade);
            dTO = mapper.Map<ServicoDTO>(entidade);
            return dTO;
        }
    }
}
