using AutoMapper;
using Entidades;
using Interfaces.Models;
using Interfaces.Repository;
using ProjetoFinal.DTOs;

namespace Projeto_Final.Models
{
    public class PagamentoModels : IPagamentoModels
    {
        private IPagamentoRepository repository;
        private IMapper mapper;

        public PagamentoModels(IPagamentoRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void delete(int id)
        {
            this.repository.delete(id);
        }

        public IEnumerable<PagamentoDTO> getAll()
        {
            return mapper.Map<IEnumerable<PagamentoDTO>>(repository.getAll());
        }

        public PagamentoDTO GetPagamento(int id)
        {
            var pagamento = this.repository.GetPagamento(id);
            return mapper.Map<PagamentoDTO>(pagamento);
        }

        public PagamentoDTO recuperar(Func<Pagamento, bool> expressao)
        {
            var pagamento = this.repository.recuperar(expressao);
            return mapper.Map<PagamentoDTO>(pagamento);
        }

        public PagamentoDTO save(PagamentoDTO dTO)
        {
            Pagamento entidade = mapper.Map<Pagamento>(dTO);

            if (entidade.id == 0)
                repository.addPagamento(entidade);
            else
                repository.updatePagamento(entidade);
            dTO = mapper.Map<PagamentoDTO>(entidade);
            return dTO;
        }
    }
}
