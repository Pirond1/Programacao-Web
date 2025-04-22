using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IFuncionarioRepository
    {
        IEnumerable<Funcionario> getAll();
        Funcionario addFuncionario(Funcionario funcionario);

        void delete(int id);

        Funcionario GetFuncionario(int id);
        Funcionario updateFuncionario(Funcionario funcionario);

        Funcionario recuperar(Func<Funcionario, bool> expressao);
    }
}
