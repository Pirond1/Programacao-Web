using AutoMapper;
using Entidades;
using Interfaces.Models;
using Interfaces.Repository;
using ProjetoFinal.DTOs;

namespace Projeto_Final.Models
{
    public class FuncionarioModels : IFuncionarioModels
    {
        private IFuncionarioRepository repository;
        private IMapper mapper;

        public FuncionarioModels(IFuncionarioRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public FuncionarioDTO validarLogin(string usuario, string senha)
        {
            var usu =
                repository.recuperar(p => p.usuario == usuario
                && p.senha == senha);
            return mapper.Map<FuncionarioDTO>(usu);
        }

        public void delete(int id)
        {
            this.repository.delete(id);
        }

        public IEnumerable<FuncionarioDTO> getAll()
        {
            return mapper.Map<IEnumerable<FuncionarioDTO>>(repository.getAll());
        }

        public FuncionarioDTO GetFuncionario(int id)
        {
            var funcionario = this.repository.GetFuncionario(id);
            return mapper.Map<FuncionarioDTO>(funcionario);
        }

        public FuncionarioDTO recuperar(Func<Funcionario, bool> expressao)
        {
            var funcionario = this.repository.recuperar(expressao);
            return mapper.Map<FuncionarioDTO>(funcionario);
        }

        public FuncionarioDTO save(FuncionarioDTO dTO)
        {
            Funcionario entidade = mapper.Map<Funcionario>(dTO);

            if (entidade.id == 0)
                repository.addFuncionario(entidade);
            else
                repository.updateFuncionario(entidade);
            dTO = mapper.Map<FuncionarioDTO>(entidade);
            return dTO;
        }
    }
}
