using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> getAll();
        Cliente addCliente(Cliente cliente);

        void delete(int id);

        Cliente GetCliente(int id);
        Cliente updateCliente(Cliente cliente);

        Cliente recuperar(Func<Cliente, bool> expressao);
    }
}
