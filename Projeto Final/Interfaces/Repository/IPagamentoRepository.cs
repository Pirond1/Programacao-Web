using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IPagamentoRepository
    {
        IEnumerable<Pagamento> getAll();
        Pagamento addPagamento(Pagamento pagamento);

        void delete(int id);

        Pagamento GetPagamento(int id);
        Pagamento updatePagamento(Pagamento pagamento);

        Pagamento recuperar(Func<Pagamento, bool> expressao);
    }
}
