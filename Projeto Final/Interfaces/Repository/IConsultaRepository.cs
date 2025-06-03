using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IConsultaRepository
    {
        IEnumerable<Consulta> getAll();
        Consulta addConsulta(Consulta consulta);

        void delete(int id);

        Consulta GetConsulta(int id);
        Consulta updateConsulta(Consulta consulta);

        Consulta recuperar(Func<Consulta, bool> expressao);
    }
}
