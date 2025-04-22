using Entidades;
using ProjetoFinal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface IAreaModels
    {
        IEnumerable<AreaDTO> getAll();
        AreaDTO save(AreaDTO dTO);

        void delete(int id);

        AreaDTO GetArea(int id);

        AreaDTO recuperar(Func<Area, bool> expressao);
    }
}
