using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IServicoRepository
    {
        IEnumerable<Servico> getAll();
        Servico addServico(Servico servico);

        void delete(int id);

        Servico GetServico(int id);
        Servico updateServico(Servico servico);

        Servico recuperar(Func<Servico, bool> expressao);
    }
}
