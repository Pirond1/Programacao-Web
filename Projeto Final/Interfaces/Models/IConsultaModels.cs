using Entidades;
using ProjetoFinal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface IConsultaModels
    {
        IEnumerable<ConsultaDTO> getAll();
        ConsultaDTO save(ConsultaDTO dTO);

        void delete(int id);

        ConsultaDTO GetConsulta(int id);

        ConsultaDTO recuperar(Func<Consulta, bool> expressao);

    }
}
