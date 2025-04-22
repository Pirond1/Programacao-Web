using Entidades;
using InfraEstrutura.Contexto;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
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

        public void delete(int id)
        {
            //recuperei obj da base 
            var obj = this.contexto.Set<Area>().Find(id);
            if (obj != null)
            {
                //excluir
                this.contexto.Set<Area>().Remove(obj);
                this.contexto.SaveChanges();
            }
        }

        public IEnumerable<Area> getAll()
        {
            return this.contexto.Set<Area>().ToList().OrderBy(a => a.descricao);
        }

        public Area GetArea(int id)
        {
            return this.contexto.Set<Area>().Find(id);
        }

        public Area recuperar(Func<Area, bool> expressao)
        {
            return this.contexto.Set<Area>().Where(expressao).FirstOrDefault();
        }

        public Area updateArea(Area area)
        {
            var prodaux = contexto.Set<Area>().Find(area.id);



            if (prodaux != null)
            {
                contexto.Entry(prodaux).State = EntityState.Detached;
                this.contexto.Set<Area>().Update(area);
                this.contexto.SaveChanges();
            }


            return area;
        }
    }
}
