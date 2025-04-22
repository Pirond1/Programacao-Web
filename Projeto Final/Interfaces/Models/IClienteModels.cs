using Entidades;
using ProjetoFinal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface IClienteModels
    {
        IEnumerable<ClienteDTO> getAll();
        ClienteDTO save(ClienteDTO dTO);

        void delete(int id);

        ClienteDTO GetCliente(int id);

        ClienteDTO recuperar(Func<Cliente, bool> expressao);
    }
}
