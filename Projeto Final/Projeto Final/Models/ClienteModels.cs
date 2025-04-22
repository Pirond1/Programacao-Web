using AutoMapper;
using Interfaces.Models;
using ProjetoFinal.DTOs;
using Entidades;
using Interfaces.Repository;

namespace Projeto_Final.Models
{
    public class ClienteModels : IClienteModels
    {
        private IClienteRepository repository;
        private IMapper mapper;

        public ClienteModels(IClienteRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void delete(int id)
        {
            this.repository.delete(id);
        }

        public IEnumerable<ClienteDTO> getAll()
        {
            return mapper.Map<IEnumerable<ClienteDTO>>(repository.getAll());
        }

        public ClienteDTO GetCliente(int id)
        {
            var cliente = this.repository.GetCliente(id);
            return mapper.Map<ClienteDTO>(cliente);
        }

        public ClienteDTO recuperar(Func<Cliente, bool> expressao)
        {
            var cliente = this.repository.recuperar(expressao);
            return mapper.Map<ClienteDTO>(cliente);
        }

        public ClienteDTO save(ClienteDTO dTO)
        {
            Cliente entidade = mapper.Map<Cliente>(dTO);

            if (entidade.id == 0)
                repository.addCliente(entidade);
            else
                repository.updateCliente(entidade);
            dTO = mapper.Map<ClienteDTO>(entidade);
            return dTO;
        }
    }
}
