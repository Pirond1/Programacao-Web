using Entidades;
using ProjetoFinal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface IServicoModels
    {
        IEnumerable<ServicoDTO> getAll();
        ServicoDTO save(ServicoDTO dTO);

        void delete(int id);

        ServicoDTO GetServico(int id);

        ServicoDTO recuperar(Func<Servico, bool> expressao);
    }
}
