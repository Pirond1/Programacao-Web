using Entidades;
using InfraEstrutura.Contexto;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AreaRepository : IAreaRepository
    {
        private ContextoClinica contexto;

        public AreaRepository(ContextoClinica contexto)
        {
            this.contexto = contexto;
        }

        public Area addArea(Area area)
        {
            this.contexto.Set<Area>().Add(area);
            this.contexto.SaveChanges();
            return area;
        }

        public IEnumerable<Area> getAll()
        {
            return this.contexto.Set<Area>().ToList().OrderBy(a => a.descricao);
        }
    }
}
