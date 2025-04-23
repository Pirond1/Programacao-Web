using Entidades;
using ProjetoFinal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface IPagamentoModels
    {
        IEnumerable<PagamentoDTO> getAll();
        PagamentoDTO save(PagamentoDTO dTO);

        void delete(int id);

        PagamentoDTO GetPagamento(int id);

        PagamentoDTO recuperar(Func<Pagamento, bool> expressao);
    }
}
