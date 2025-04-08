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
    }
}
