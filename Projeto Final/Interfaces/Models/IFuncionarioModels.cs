using Entidades;
using ProjetoFinal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface IFuncionarioModels
    {
        IEnumerable<FuncionarioDTO> getAll();
        FuncionarioDTO save(FuncionarioDTO dTO);

        void delete(int id);

        FuncionarioDTO GetFuncionario(int id);

        FuncionarioDTO recuperar(Func<Funcionario, bool> expressao);
    }
}
