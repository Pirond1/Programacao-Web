using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IAreaRepository
    {
        IEnumerable<Area> getAll();
        Area addArea(Area area);
    }
}
